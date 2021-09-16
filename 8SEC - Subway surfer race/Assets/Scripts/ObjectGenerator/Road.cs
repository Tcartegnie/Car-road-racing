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

	public void InitRaod(Score score)
	{
		coinGenerator.Score = score;
		GenerateBuilding();
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
		coinGenerator.RemoveObject();
		bonusgGenerator.RemoveObject();
		trainGenerator.RemoveObject();
	}
	public void ClearBuilding()
	{
		buildingGenerator.RemoveObject();
	}

	public void ConstructRoad()
	{
		GenerateBuilding();	
	}

	public void GenerateTrain(RoadSegements segement)
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
}
