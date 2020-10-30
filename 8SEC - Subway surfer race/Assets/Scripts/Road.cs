using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
	[SerializeField]
	CoinGenerator coinGenerator;
	[SerializeField]
	BuildingGenerator BuildingGenerator;
	[SerializeField]
	BonusGenerator BonusgGenerator;
	[SerializeField]
	TrainGenerator TrainGenerator;



	public void ChangeRoadPattern()
	{
		ClearPattern();
		ConstructRoad();
	}

	public void ClearPattern()
	{
		coinGenerator.RemoveObject();
		BuildingGenerator.RemoveObject();
		BonusgGenerator.RemoveObject();
	}


	public void ConstructRoad()
	{
		GenerateBonus();
		GenerateCoins();
		GenerateBuilding();	
	}

	public void GenerateTrain(RoadSegements segement)
	{
		TrainGenerator.GenerateTrainSegement(segement);
	}
	public void GenerateBonus()
	{
		BonusgGenerator.GenerateBonus();
	}

	public void GenerateCoins()
	{
		coinGenerator.GenerateCoins();
	}

	public void GenerateBuilding()
	{
		BuildingGenerator.GenerateBuilding();
	}
}
