using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoadPatternList", menuName = "ScriptableObjects/RoadPatternList", order = 1)]
public class RoadPatternList : ScriptableObject
{
	public List<Roads> Roads;
	int LastPatternID = -1;

	public Roads GetRandomRoadPattern()
	{
		LastPatternID = Random.Range(0, Roads.Count);

		return Roads[LastPatternID];
			
	}
}
