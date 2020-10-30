using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager
{
    RoadList TrainList;
    int CurrentSegementCount = 0;
    SegementDifficulty CurrentDifficulty = SegementDifficulty.Easy;
    RoadPattern CurrentPatterns;
  

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

    public RoadSegements GetNextSegement()
    {
        if (!IsPatternOver())
        {
            CurrentSegementCount++;
        }
        return GetCurrentRoadSegement();
    }

    public RoadSegements GetCurrentRoadSegement()
	{
        return CurrentPatterns.segments[CurrentSegementCount];
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
