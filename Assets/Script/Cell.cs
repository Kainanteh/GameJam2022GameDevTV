using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
	[SerializeField]
	public int x, z;

	[SerializeField]
	public int[] DirectionAllowed = new int[4];



}
