using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainGenerator : ObjectGenerator
{
	GameObject [] Trains = new GameObject[5];
	public void GenerateTrainSegement(RoadSegements segement)
	{
		for (int i = 0; i < segement.Train.Length; i++)
		{
			if(segement.Train[i])
			{
				GenerateTrain(segement.name[i], i);
			}
		}
	}

	public void RemoveTrain(int LaneID)
	{
		if (Trains[LaneID] != null)
		{
			RemoveObject(Trains[LaneID]);
		}
	}

	private GameObject GenerateTrain(string name, int i)
	{
		GameObject GO = GenerateObject(name, i);
		Trains[i] = GO;
		return GO;
	}

	public GameObject GenerateTrain(int LaneID)
	{
		return GenerateTrain("Train", LaneID);
	}



}
