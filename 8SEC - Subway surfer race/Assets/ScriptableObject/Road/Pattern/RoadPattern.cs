
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RoadPattern 
{
	public string PatternName;
	public List<RoadSegements> segments = new List<RoadSegements>();
	public SegementDifficulty difficulty;

	public void MakeSegment(TrainType [] names,bool[] trains, bool[] coins,bool[]Bonus)
	{
		RoadSegements segement = CreateSegement(names, trains, coins, Bonus);
		AddSegements(segement);
	}

	private RoadSegements CreateSegement(TrainType[] names, bool[] trains, bool[] coins, bool[] Bonus)
	{
		RoadSegements segement = new RoadSegements(names, trains, coins, Bonus);
		return segement;
	}

	public void AddSegements(RoadSegements segment)
	{
		segments.Add(segment);
	}

	public void SaveSegement()
	{
		JsonUtility.FromJsonOverwrite(Application.persistentDataPath +"/"+ PatternName, segments);
	}

	public List<RoadSegements> LoadPattern(string patternName)
	{
		var list =	JsonUtility.FromJson<List<RoadSegements>>(Application.persistentDataPath + "/.*");
		return list;
	}
}
