using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoadPatternList", menuName = "ScriptableObjects/RoadPatternList", order = 1)]
public class RoadPatternList : ScriptableObject
{
	public List<RoadList> Roads;

	public RoadList GetRoadPatternList()
	{
		return Roads[Random.Range(0, Roads.Count)];
	}
}
