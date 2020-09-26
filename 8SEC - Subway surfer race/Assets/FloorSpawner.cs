using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
	public GameObject BasicRoadPattern;
	public Transform RoadSpawnPoint;
	public RoadPatternList roadLists;
	public int SpawnRoadNumber;
	public bool SpanwCamionEnable;
	RoadManager roadManager;


	List<GameObject> TransformRoad = new List<GameObject>();

	GameObject LastRoad;
	public void Awake()
	{
		roadManager = new RoadManager(roadLists);
	}

	public void InitSpawn()
	{
		for (int j = 0; j < SpawnRoadNumber; j++)
		{
			GameObject GO = Instantiate(BasicRoadPattern, RoadSpawnPoint.position + ((Vector3.forward * 39) * j), new Quaternion());
			TransformRoad.Add(GO);
			LastRoad = GO;
		}
	}


	public void ResetPattern()
	{
		for (int i = 0; i < TransformRoad.Count; i++)
		{
			TransformRoad[i].GetComponent<Road>().ChangeRoadPattern(BasicRoadPattern);
		}
	}


	public void resetRoadSegement(int segementID)
	{
		Road CurrentRoad = TransformRoad[segementID].GetComponent<Road>();
		TransformRoad[segementID].transform.position = LastRoad.transform.position + transform.forward * 39;
		CurrentRoad.ChangeRoadPattern(roadManager.GetCurrentSegement());
		LastRoad = TransformRoad[segementID];
	}

	public void FixedUpdate()
	{
		for (int  i = 0;i < TransformRoad.Count;i++)
		{
			if(TransformRoad[i].transform.position.z < -39)
			{
				resetRoadSegement(i);
			}
		}
	}


}
