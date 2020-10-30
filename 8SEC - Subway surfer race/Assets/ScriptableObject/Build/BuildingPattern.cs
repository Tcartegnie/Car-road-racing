using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building pattern", menuName = "ScriptableObjects/Building pattern", order = 1)]

public class BuildingPattern : ScriptableObject
{ 
	public string[] Pattern = new string[4];
}
