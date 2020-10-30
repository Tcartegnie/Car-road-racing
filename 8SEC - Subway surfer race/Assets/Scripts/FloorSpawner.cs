using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
	public RoadList Roadlist;
	public GameObject EmptyRoadPattern;
	public Transform RoadSpawnPoint;
	//public RoadPatternList roadLists;
	public int SpawnRoadNumber;
	public bool SpawnCamionEnable;
	//RoadManager roadManager;
	public float RoadSpeed;
	public float RoadDistance;

	public List<Road> Roads = new List<Road>();

	Transform LastRoad;


	PatternManager patternManager = new PatternManager();
	public void Start()
	{
		patternManager.SetTrainList(Roadlist);
		InitSpawn();
	}

	public void InitSpawn()
	{
		ClearRoad();
		Roads.Clear();
		LastRoad = transform;
		for (int j = 0; j < SpawnRoadNumber-1; j++)
		{
			SpawnNewSegement();
		}
	}

	public void SpawnNewSegement()
	{
		GameObject GO; 
		GO = Instantiate(EmptyRoadPattern);
		GO.transform.position = LastRoad.transform.position + ((transform.forward * RoadDistance));
		GO.transform.rotation = new Quaternion();
		GO.GetComponent<Road>().GenerateBuilding();
		Roads.Add(GO.GetComponent<Road>());
		LastRoad = GO.transform;
	}


	public void RestAndStopRoad()
	{
		SpawnCamionEnable = false;
	}

	public void ResetRoadSegement(int segementID)
	{
		ResetRoadPattern(segementID);
		ResetRoadSegementPosition(segementID);
	}
	public void ResetRoadPattern(int segementID)
	{
		Road CurrentRoad = Roads[segementID];
		CurrentRoad.ChangeRoadPattern();
	}

	public void ResetRoadSegementPosition(int segementID)
	{
		Roads[segementID].transform.position = LastRoad.transform.position + transform.forward * RoadDistance;
		LastRoad = Roads[segementID].transform;
	}

	public void ClearRoad()
	{
		//roadManager.ResetPattern();
		for (int i = 0; i < Roads.Count; i++)
		{
			Roads[i].ClearPattern();
		}
	}
	public void SpawnTrainSegement(Road road)
	{
		road.GenerateTrain(patternManager.GetNextSegement());
	}
		

	public void Update()
	{
		for (int  i = 0;i < Roads.Count;i++)
		{
			if(Roads[i].transform.position.z < -RoadSpeed)
			{
				Road road = Roads[i];
				ResetRoadSegementPosition(i);
				road.GenerateBuilding();
				if (!GameManager.instance.OnPause)
				{
					SpawnTrainSegement(road);
				}
			}
		}
	}


}
