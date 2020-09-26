using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "RoadSegements", menuName = "ScriptableObjects/RoadSegements", order = 1)]
public class RoadSegements : ScriptableObject
{
	public List<GameObject> Segements;
	public bool IsCoinsSpawns;

	public GameObject GetRandomTrainSegement()
	{
		return Segements[Random.Range(0, Segements.Count)];
	}
}
