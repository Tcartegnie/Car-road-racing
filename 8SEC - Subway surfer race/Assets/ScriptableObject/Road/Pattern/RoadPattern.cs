using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CreateAssetMenu(fileName = "Road pattern", menuName = "ScriptableObjects/Road/pattern", order = 1)]
public class RoadPattern : ScriptableObject
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
}
