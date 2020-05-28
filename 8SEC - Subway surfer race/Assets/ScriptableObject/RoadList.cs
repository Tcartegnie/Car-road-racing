using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Roadlist", menuName = "ScriptableObjects/RoadList", order = 1)]
public class RoadList : ScriptableObject
{
	public List<RoadData> Roads;

	public RoadData GetRandomList()
	{
		return Roads[Random.Range(0, Roads.Count)];
	}

}
