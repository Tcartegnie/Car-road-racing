using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager
{
	public RoadPatternList PatternList;

	RoadSegements CurrentRoadSegements;

	int CurrentSegementID;

	public RoadManager(RoadPatternList patternList)
	{
		PatternList = patternList;
		GetNewRoadList();
	}

	void GetNewRoadList()
	{
		Roads roads = PatternList.GetRandomRoadPattern();
		CurrentRoadSegements = roads.GetRandomRoads();
		CurrentSegementID = 0;
	}

	public GameObject GetCurrentSegement()
	{
		return CurrentRoadSegements.Segements[CurrentSegementID];
	}

	public GameObject GetNextSegement()
	{
		if(CurrentSegementID < CurrentRoadSegements.Segements.Count)
		{
			GameObject GO = CurrentRoadSegements.Segements[CurrentSegementID];
			CurrentSegementID++;
			return GO;
		}
		else
		{
			GetNewRoadList();
		}
		return new GameObject();
	}
}
