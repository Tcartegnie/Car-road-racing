using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager
{
    RoadList TrainList;
    int CurrentSegementCount = 0;
    SegementDifficulty currentDifficulty = SegementDifficulty.Easy;
    RoadPattern CurrentPatterns;

	public SegementDifficulty CurrentDifficulty { get => currentDifficulty; set => currentDifficulty = value; }

	public void SetTrainList(RoadList List)
	{
        TrainList = List;
        GetNewList();
    }

    public void GetNewList()
	{
        CurrentSegementCount = 0;
        CurrentPatterns = TrainList.GetRandomList(CurrentDifficulty);
    }

    public void GetNextSegement()
    {
        if (!IsPatternOver())
        {
            CurrentSegementCount++;
        }
    }

    public RoadSegements GetCurrentRoadSegement()
    {
        if (CurrentPatterns.segments.Count > 0)
        {
            return CurrentPatterns.segments[CurrentSegementCount];
        }
        return new RoadSegements();
    }

    public void ResetPattern()
	{
        CurrentSegementCount = 0;
        CurrentPatterns = new RoadPattern();
	}

    public bool IsPatternOver()
	{
        if(CurrentSegementCount >= CurrentPatterns.segments.Count-1)
		{
            GetNewList();
            return true;
		}
        return false;
	}
}
