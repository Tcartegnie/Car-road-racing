using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public class RoadSegements
{

   string[] TrainName = new string[2] { "Train", "Ramp" };
   public string[] name = new string[5];
   public bool[] Train = new bool[5];
   public bool[] IsCoinSpawner = new bool[5];
   public bool[] Bonus = new bool[5];

	public RoadSegements()
	{
		Train = new bool[5];
		IsCoinSpawner = new bool[5];
		Bonus = new bool[5];
		name = new string[5];
	}

	public RoadSegements(TrainType [] name,bool[] spawns, bool[] isCoinSpawner, bool[]bonus)
	{
		SetTrainName(name);
		Train = spawns;
		IsCoinSpawner = isCoinSpawner;
		Bonus = bonus;
	}
	public void SetTrainName(TrainType[] TrainType)
	{
		for(int i = 0; i < 5;i++)
		{
			name[i] = TrainName[(int)TrainType[i]];
		}
	}
}
