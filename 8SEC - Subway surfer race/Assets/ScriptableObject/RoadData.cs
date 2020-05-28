using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class RoadDataStructure
{
	public List<GameObject> GameObject;
	public bool IsCoinsSpawns;

	public GameObject GetRandomGameObject()
	{
		return GameObject[Random.Range(0, GameObject.Count)];
	}
}

[CreateAssetMenu(fileName = "RoadData", menuName = "ScriptableObjects/RoadData", order = 1)]
public class RoadData : ScriptableObject
{
	public List<RoadDataStructure> TrainSpawn;
	public bool[] coins = new bool[5];
}



