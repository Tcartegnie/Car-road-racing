using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
	public GameObject ResetPatternObject;
	public RoadData StartRoad;
	public RoadPatternList roadList;
	public GameObject SpawnRoadPrefab;

	public GameObject LastRoad;
	public Transform RoadSpawnPoint;
	public int SpawnRoadNumber;
	public int CurrentTrainPattern = 0;
	RoadList CurrentRoadLists;
	List<RoadDataStructure> Objects;
	public List<GameObject> TransformRoad = new List<GameObject>();

	public void InitSpawn()
	{

		CurrentRoadLists = roadList.GetRoadPatternList();

		RoadData datas = CurrentRoadLists.GetRandomList();
		Objects = datas.TrainSpawn;


		for (int j = 0; j < StartRoad.TrainSpawn.Count; j++)
		{
			GameObject GO = Instantiate(SpawnRoadPrefab, RoadSpawnPoint.position + ((Vector3.forward * 39) * j), new Quaternion());
			GO.GetComponent<Road>().ChangeRoadPattern(StartRoad.TrainSpawn[j].GetRandomGameObject());
			GO.GetComponentInChildren<CoinSpawner>().SpawnCoins();
			GO.GetComponentInChildren<CoinSpawner>().SpawnBonus();
			TransformRoad.Add(GO);
			LastRoad = GO;
		}
	}

	public bool IsPatterEnd()
	{
			if (CurrentTrainPattern >= Objects.Count)
			{
				CurrentTrainPattern = 0;
				return true;
			}	
		return false;
	}

public GameObject GetBuilding()
	{
	
		if (IsPatterEnd())
		{
			Objects = roadList.GetRoadPatternList().GetRandomList().TrainSpawn;
		}
		GameObject GO = Objects[CurrentTrainPattern].GetRandomGameObject();
		CurrentTrainPattern++;
		return GO;
	
	}


	public void ResetPattern()
	{
		for (int i = 0; i < TransformRoad.Count; i++)
		{
			TransformRoad[i].GetComponent<Road>().ChangeRoadPattern(ResetPatternObject);
		}
	}

	public void FixedUpdate()
	{
	//	Debug.Break();
		for (int  i = 0;i < TransformRoad.Count;i++)
		{
			if(TransformRoad[i].transform.position.z < -39)
			{
				//TransformRoad[i].GetComponentInChildren<CoinSpawner>().RemoveCoin();
				TransformRoad[i].transform.position = LastRoad.transform.position + transform.forward * 39;
				TransformRoad[i].GetComponent<Road>().ChangeRoadPattern(GetBuilding());
				LastRoad = TransformRoad[i];
			}
		}
	}


}
