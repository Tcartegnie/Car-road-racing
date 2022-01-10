using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager
{
    RoadList TrainList;
    int CurrentSegementCount = 0;
    SegementDifficulty currentDifficulty = SegementDifficulty.Easy;
    RoadPattern CurrentPatterns;
    RoadSegements EmptyPattern;
    bool InEditor;
	public PatternManager(RoadList trainList, RoadSegements emptyPattern)
	{
		TrainList = trainList;
		EmptyPattern = emptyPattern;
	}

	public SegementDifficulty CurrentDifficulty { get => currentDifficulty; set => currentDifficulty = value; }

    public void SetEditorMode(bool State)
	{
        InEditor = State;
	}

	public void SetTrainList(RoadList List)
	{
        TrainList = List;
        GetNewPattern();
    }

    public void GetNewPattern()
	{
        CurrentSegementCount = 0;
        CurrentPatterns = TrainList.GetRandomList(CurrentDifficulty);
    }

    public RoadSegements GetNextSegement()
    {
        if (!IsPatternOver())
        {
            RoadSegements segement = GetCurrentRoadSegement();
            CurrentSegementCount++;
            return segement;
        }
        else
		{
            GetNewPattern();
            return EmptyPattern;
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
        return CurrentSegementCount >= CurrentPatterns.segments.Count-1;
	}
}
