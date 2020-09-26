using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Roads", menuName = "ScriptableObjects/Roads", order = 1)]
public class Roads : ScriptableObject
{
	public List<RoadSegements> roads;

	public RoadSegements GetRandomRoads()
	{
		return roads[Random.Range(0, roads.Count)];
	}

}
