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
	public bool SpawnCamionEnable;
	public bool SpawnCoinEnable;
	public bool SpawnBonusEnable;
	public bool GenerateBuild;

	[Space]
	public float RoadSpeed;
	public float RoadDistance;
	public float DistanceMaxFromStart;

	public List<Road> Roads = new List<Road>();

	Transform LastRoad;


	PatternManager patternManager;

	
	public void Start()
	{
		patternManager = new PatternManager(Roadlist, EmptyPattern);
		patternManager.SetTrainList(Roadlist);
		InitSpawn();
	}

	public void Update()
	{
		for (int i = 0; i < Roads.Count; i++)
		{
			if (Roads[i].transform.position.z < -DistanceMaxFromStart)
			{
				Road road = Roads[i];
				road.ClearAll();
				ResetRoadSegementPosition(i);
				road.GenerateBuilding();
				if (!GameManager.instance.OnPause)
				{
					SpawnPattern(road);
				}
			}
		}
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
		//GO.GetComponent<Road>().InitRaod(score);
		GO.GetComponent<MovingObject>().speed = RoadSpeed;
		Roads.Add(GO.GetComponent<Road>());
		LastRoad = GO.transform;
	}

	public void GetNewRandomPattern()
	{
		patternManager.GetNewPattern();
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
		patternManager.GetNewPattern();
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
		if (GenerateBuild)
		{
			Road CurrentRoad = Roads[segementID];
			CurrentRoad.ChangeRoadPattern();
		}
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

	public void SpawnTrainSegement(Road road, RoadSegements segement)
	{
		if (SpawnCamionEnable)
		{
			road.GenerateTrain(segement);
		}
	}
	
	public void SpawnCoinsSegement(Road road, RoadSegements segement)
	{
		if (SpawnCoinEnable)
		{
			road.GenerateCoins(segement);
		}
	}
	public void SpawnBonusSegement(Road road, RoadSegements segement)
	{
		if (SpawnBonusEnable)
		{
			road.GenerateBonus(segement);
		}
	}
	public void SpawnPattern(Road road)
	{
		RoadSegements segement = patternManager.GetNextSegement();
		SpawnTrainSegement(road,segement);
		SpawnCoinsSegement(road, segement);
		SpawnBonusSegement(road, segement);
	}




}
