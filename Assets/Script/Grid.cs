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

	void Awake()
	{
		cellObject = new GameObject[height * width];
		cellScript = new Cell[height * width];

		for (int z = 0, i = 0; z < height; z++)
		{
			for (int x = 0; x < width; x++)
			{
				CreateCell(x, z, i++);
			}
		}
	}

	void CreateCell(int x, int z, int i)
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
