using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public Score score;
    public FloorSpawner floorSpawner;
    public int NormalDifficultyMax;
    public int HardDifficultyMax;
    


  
    SegementDifficulty currentDifficulty = SegementDifficulty.Easy;
    void Update()
	{
		CheckDifficulty();
		floorSpawner.SetDifficulty(GetDifficulty());
	}

	private void CheckDifficulty()
	{
		int currentScore = score.GetScore();
		if (currentScore < NormalDifficultyMax)
		{
			currentDifficulty = SegementDifficulty.Easy;
		}
		else if (currentScore < HardDifficultyMax)
		{
			currentDifficulty = SegementDifficulty.Normal;
		}
		else
		{
			currentDifficulty = SegementDifficulty.Hard;
		}
	}


	public void SetDifficulty(SegementDifficulty difficulty)
    {
        currentDifficulty = difficulty;
    }

    public SegementDifficulty GetDifficulty()
	{
        return currentDifficulty;
	}


}
