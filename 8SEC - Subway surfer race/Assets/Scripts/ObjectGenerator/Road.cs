using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
	[SerializeField]
	CoinGenerator coinGenerator;
	[SerializeField]
	BuildingGenerator buildingGenerator;
	[SerializeField]
	BonusGenerator bonusgGenerator;
	[SerializeField]
	TrainGenerator trainGenerator;

	public void Start()
	{
		
	}

	public void InitRaod(Score score)
	{
		coinGenerator.Score = score;
	}

	public void SetBonusList(BonusList list)
	{
		bonusgGenerator.SetBonusList(list);
	}
	public void ChangeRoadPattern()
	{	
		ConstructRoad();
	}

	public void ClearAll()
	{
		ClearPattern();
		ClearBuilding();
	}

	public void ClearPattern()
	{
		coinGenerator.RemoveObjects();
		bonusgGenerator.RemoveObjects();
		trainGenerator.RemoveObjects();
	}
	public void ClearBuilding()
	{
		buildingGenerator.RemoveObjects();
	}

	public void ConstructRoad()
	{
		GenerateBuilding();	
	}

	public void RemoveTrain(int LaneID)
	{
		trainGenerator.RemoveTrain(LaneID);
	}

	public GameObject GenerateTrain(int LaneID)
	{
		return trainGenerator.GenerateTrain(LaneID);
	}

	public void GenerateTrains(RoadSegements segement)
	{
		trainGenerator.GenerateTrainSegement(segement);
	}
	public void GenerateBonus(RoadSegements segement)
	{
		bonusgGenerator.GenerateBonus(segement);
	}

	public void GenerateCoins(RoadSegements segement)
	{
		coinGenerator.GenerateCoins(segement);
	}

	public void GenerateBuilding()
	{
		buildingGenerator.GenerateBuilding();
	}

	public Vector3 GetTrainSpawnerPosition(int LaneID)
	{
		return trainGenerator.GetLanePositon(LaneID);
	}
	
}
