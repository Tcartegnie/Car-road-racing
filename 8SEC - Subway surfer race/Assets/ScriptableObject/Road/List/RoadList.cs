using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SegementDifficulty
{
	Easy,
	Normal,
	Hard,
}

public enum TrainType
{
	Train,
	Ramp
}

public class RoadList 
{
	public List<RoadPattern> patterns = new List<RoadPattern>();

	public RoadPattern GetRandomList(SegementDifficulty Difficulty)
	{
		List<RoadPattern> patternByDifficulty = patterns.FindAll(value => value.difficulty == Difficulty);
		return patternByDifficulty[Random.Range(0, patternByDifficulty.Count)];
	}

	public void LoadList()
	{

	}

}
