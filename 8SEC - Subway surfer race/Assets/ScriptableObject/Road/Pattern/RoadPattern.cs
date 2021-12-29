
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RoadPattern 
{
	public List<RoadSegements> segments = new List<RoadSegements>();
	public SegementDifficulty difficulty;

	public void MakeSegment(SegementDifficulty difficulty,TrainType [] names,bool[] trains, bool[] coins,bool[]Bonus)
	{
		this.difficulty = difficulty;
		RoadSegements segement = new RoadSegements(names, trains,coins, Bonus);
		AddSegements(segement);
	}

	public void AddSegements(RoadSegements segment)
	{
		segments.Add(segment);
	}

	public void SaveSegement()
	{
		JsonUtility.FromJsonOverwrite(Application.dataPath,segments);
	}

	public List<RoadSegements> LoadPattern(string name)
	{
		var list =	JsonUtility.FromJson<List<RoadSegements>>(Application.dataPath + name);
		return list;
	}
}
