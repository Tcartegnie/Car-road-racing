using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
	public GameObject EmptyRoadPattern;
	public Transform RoadSpawnPoint;
	public RoadPatternList roadLists;
	public int SpawnRoadNumber;
	public bool SpawnCamionEnable;
	RoadManager roadManager;


	public List<GameObject> TransformRoad = new List<GameObject>();

	GameObject LastRoad;
	public void Awake()
	{
		roadManager = new RoadManager(roadLists);
	}

	public void InitSpawn()
	{
		TransformRoad.Clear();
		for (int j = 0; j < SpawnRoadNumber; j++)
		{
			GameObject GO = Instantiate(EmptyRoadPattern, RoadSpawnPoint.position + ((Vector3.forward * 20) * j), new Quaternion());
			TransformRoad.Add(GO);
			LastRoad = GO;
		}
	}


	public void ResetPattern()
	{
		roadManager.ResetPattern();
		for (int i = 0; i < TransformRoad.Count; i++)
		{
			TransformRoad[i].GetComponent<Road>().ChangeRoadPattern(EmptyRoadPattern,RoadSpawnPoint);
		}
		
	}

	public void RestAndStopRoad()
	{
		ResetPattern();
		SpawnCamionEnable = false;
	}

	public void resetRoadSegement(int segementID)
	{
		Road CurrentRoad = TransformRoad[segementID].GetComponent<Road>();
		CurrentRoad.ChangeRoadPattern(roadManager.GetNextSegement(),RoadSpawnPoint);
		TransformRoad[segementID].transform.position = LastRoad.transform.position + transform.forward * 20;
		LastRoad = TransformRoad[segementID];
	}

	public void Update()
	{
		for (int  i = 0;i < TransformRoad.Count;i++)
		{
			if(TransformRoad[i].transform.position.z < -20)
			{
				if (SpawnCamionEnable)
				{
					resetRoadSegement(i);
				}
			}
		}
	}


}
