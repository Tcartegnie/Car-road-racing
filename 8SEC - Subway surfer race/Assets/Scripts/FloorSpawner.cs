using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
	public RoadSegements EmptyPattern;
	public RoadList Roadlist;
	public BonusList bonusList;
	public Score score;
	public DifficultyManager Difficultymanager;

	[Space]
	public GameObject EmptyRoadPattern;
	public Transform RoadSpawnPoint;

	[Space]
	public int SpawnRoadNumber;
	bool SpawnCamionEnable;
	bool SpawnCoinEnable;
	bool SpawnBonusEnable;

	[Space]
	public float RoadSpeed;
	public float RoadDistance;
	public float DistanceMaxFromStart;

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
		GO.GetComponent<Road>().SetBonusList(bonusList);
		GO.GetComponent<Road>().InitRaod(score);
		GO.GetComponent<MovingObject>().speed = RoadSpeed;
		Roads.Add(GO.GetComponent<Road>());
		LastRoad = GO.transform;
	}

	public void GetNewRandomPattern()
	{
		patternManager.GetNewList();
	}

	public void SetDifficulty(SegementDifficulty NewDifficulty)
	{
		patternManager.CurrentDifficulty = NewDifficulty;
	}

	public void RestAndStopRoad()
	{
		ResetPattern();
		SpawnCamionEnable = false;
		SpawnBonusEnable = false;
		SpawnCoinEnable = false;
	}


	public void EnableRoadPattern()
	{
		patternManager.GetNewList();
		SpawnCamionEnable = true;
		SpawnBonusEnable = true;
		SpawnCoinEnable = true;
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
		
		for (int i = 0; i < Roads.Count; i++)
		{
			Roads[i].ClearPattern();
		}
	}

	public void ResetPattern()
	{
		ClearRoad();
		patternManager.ResetPattern();
	}

	public void SpawnTrainSegement(Road road)
	{
		if (SpawnCamionEnable)
		{
			road.GenerateTrain(patternManager.GetCurrentRoadSegement());
		}
	}
	
	public void SpawnCoinsSegement(Road road)
	{
		if (SpawnCoinEnable)
		{
			road.GenerateCoins(patternManager.GetCurrentRoadSegement());
		}
	}
	public void SpawnBonusSegement(Road road)
	{
		if (SpawnBonusEnable)
		{
			road.GenerateBonus(patternManager.GetCurrentRoadSegement());
		}
	}
	public void SpawnPattern(Road road)
	{
		
		SpawnTrainSegement(road);
		SpawnCoinsSegement(road);
		SpawnBonusSegement(road);
		patternManager.GetNextSegement();
	}

	public void Update()
	{
		for (int  i = 0;i < Roads.Count;i++)
		{
			if(Roads[i].transform.position.z < -DistanceMaxFromStart)
			{
				Road road = Roads[i];
				road.ClearPattern();
				road.ClearBuilding();
				ResetRoadSegementPosition(i);
				road.GenerateBuilding();
				if (!GameManager.instance.OnPause)
				{
					SpawnPattern(road);
				}
			}
		}
	}


}
