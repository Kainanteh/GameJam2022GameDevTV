using System.Collections;
using System.Collections.Generic;
using UnityEngine;







public class Grid : MonoBehaviour
{

	public int width = 6;
	public int height = 6;

	public GameObject cellPrefab;

	public GameObject[] cellObject;
	public Cell[] cellScript;

	public float offsetCell = 2f;



	int[,][] MapAllowDirections = new int[6,6][];
	

	void Awake()
	{

		// { N, E, S, W}
		MapAllowDirections[0, 0] = new int[] { 1, 0, 1, 0 };
		MapAllowDirections[0, 1] = new int[] { 1, 0, 1, 0 };
		MapAllowDirections[0, 2] = new int[] { 1, 0, 1, 0 };
		MapAllowDirections[0, 3] = new int[] { 0, 1, 1, 0 };

        MapAllowDirections[1, 3] = new int[] { 0, 1, 0, 1 };
        MapAllowDirections[2, 3] = new int[] { 0, 1, 1, 1 };
        MapAllowDirections[3, 3] = new int[] { 0, 1, 1, 1 };
        MapAllowDirections[4, 3] = new int[] { 0, 1, 1, 1 };
        MapAllowDirections[5, 3] = new int[] { 0, 0, 1, 1 };
        MapAllowDirections[5, 2] = new int[] { 1, 0, 1, 1 };
        MapAllowDirections[5, 1] = new int[] { 1, 0, 1, 1 };
        MapAllowDirections[2, 2] = new int[] { 1, 1, 1, 0 };
        MapAllowDirections[3, 2] = new int[] { 1, 1, 1, 1 };
        MapAllowDirections[4, 2] = new int[] { 1, 1, 1, 1 };
        MapAllowDirections[2, 1] = new int[] { 1, 1, 1, 0 };
        MapAllowDirections[3, 1] = new int[] { 1, 1, 1, 1 };
        MapAllowDirections[4, 1] = new int[] { 1, 1, 1, 1 };
        MapAllowDirections[2, 0] = new int[] { 1, 1, 1, 0 };
        MapAllowDirections[3, 0] = new int[] { 1, 1, 0, 1 };
        MapAllowDirections[4, 0] = new int[] { 1, 1, 0, 1 };
        MapAllowDirections[5, 0] = new int[] { 1, 0, 0, 1 };
    

	


		cellObject = new GameObject[height * width];
		cellScript = new Cell[height * width];


		for (int z = 0, i = 0; z < height; z++)
		{
			for (int x = 0; x < width; x++)
			{
				Cell ScriptCell = CreateCell(x, z, i++);

                ScriptCell.NumcellText.text = x + " " + z; 

				if (MapAllowDirections[x, z] == null)
				{ continue; }

				if(x == 4 && z == 0)
                {
			
					ScriptCell.Mytype.Type = TypeCell.CoffinSpawn;
					ScriptCell.Mytype.TypeDirection = FaceDirection.South;

				}

				if (x == 5 && z == 1)
				{
					ScriptCell.Mytype.Type = TypeCell.Cremator;
					ScriptCell.Mytype.TypeDirection = FaceDirection.East;
				}

                if (x == 2 && z == 1)
                {
                    ScriptCell.Mytype.Type = TypeCell.ExtractorMagic;
                    ScriptCell.Mytype.TypeDirection = FaceDirection.West;
                }

                if (x == 4 && z == 3)
                {
                    ScriptCell.Mytype.Type = TypeCell.Golem;
                    ScriptCell.Mytype.TypeDirection = FaceDirection.North;
                }
				if (x == 0 && z == 0)
                {
                    ScriptCell.Mytype.Type = TypeCell.Lever;
                    ScriptCell.Mytype.TypeDirection = FaceDirection.East;
                }


				try
				{
					ScriptCell.DirectionAllowed = new int[4];
					ScriptCell.DirectionAllowed[0] = MapAllowDirections[x, z][0];
					ScriptCell.DirectionAllowed[1] = MapAllowDirections[x, z][1];
					ScriptCell.DirectionAllowed[2] = MapAllowDirections[x, z][2];
					ScriptCell.DirectionAllowed[3] = MapAllowDirections[x, z][3];
				}
				catch (System.IndexOutOfRangeException e) 
				{

				}

			}
		}
	}

	Cell CreateCell(int x, int z, int i)
	{
		Vector3 position;
		position.x = x * offsetCell;
		position.y = 0f;
		position.z = z * offsetCell;

		GameObject cell = cellObject[i] = Instantiate<GameObject>(cellPrefab);
		cell.transform.SetParent(transform, false);
		cell.transform.localPosition = position;
		cell.name = "Cell- " + x + " " + z;

		cellScript[i] = cell.GetComponent<Cell>();
		cellScript[i].x = x;
		cellScript[i].z = z;

		return cell.GetComponent<Cell>();

	}

	public Cell GetCell(int posx, int posz)
    {

		for (int i = 0; i < cellScript.Length; i++)
		{
			//Debug.Log(cellScript[i].name);
			if (cellScript[i].x == posx && cellScript[i].z == posz)
			{
				return cellScript[i];
			}
		}


		return null;

	}

}
