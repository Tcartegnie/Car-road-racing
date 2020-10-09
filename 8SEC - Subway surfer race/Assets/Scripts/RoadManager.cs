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

	GameObject GetCurrentSegement()
	{
		return CurrentRoadSegements.Segements[CurrentSegementID];
	}

	public bool IsPatternEnd()
	{
		if(CurrentSegementID >= CurrentRoadSegements.Segements.Count)
		{
			return true;
		}
		return false;
	}

	public GameObject GetNextSegement()
	{
		if(IsPatternEnd())
		{
			GetNewRoadList();
			
		}
		GameObject GO = GetCurrentSegement();
		GO.name = GetCurrentSegement().name; 
		CurrentSegementID++;
		return GO;
	}

	public void ResetPattern()
	{
		CurrentSegementID = 0;
	}
}
