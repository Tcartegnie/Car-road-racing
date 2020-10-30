using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building list", menuName = "ScriptableObjects/Building list", order = 1)] 
public class BuildingList : ScriptableObject
{
	public List<BuildingPattern> Patterns = new List<BuildingPattern>();

	public BuildingPattern GetRandomList()
	{
		int PatternsID = Patterns.Count;
		Debug.Log(PatternsID);
		return Patterns[Random.Range(0, PatternsID)];
	}
}