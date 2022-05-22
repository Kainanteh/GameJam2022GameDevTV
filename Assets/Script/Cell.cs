using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum TypeCell { Default, CoffinSpawn }

public class TypeCellClass
{

	public TypeCell Type;
	public FaceDirection TypeDirection;

    public TypeCellClass(TypeCell type, FaceDirection typeDirection)
    {
        Type = type;
        TypeDirection = typeDirection;
    }
}

public class Cell : MonoBehaviour
{
	[SerializeField]
	public int x, z;

	[SerializeField]
	public int[] DirectionAllowed = new int[4];

	public TextMeshProUGUI NumcellText;
	
	public TypeCellClass Mytype;

    private void Awake()
    {
        Mytype = new TypeCellClass(TypeCell.Default,FaceDirection.North);
    }

}
