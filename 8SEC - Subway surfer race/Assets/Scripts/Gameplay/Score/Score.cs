using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{


	public int ScorePerSec;
	public int Multiplicator;
	public float ScoreIncrementalTime;
	public float ScoreBonusReach;
	[Space]

	public PauseMenu menu;
	public ScoreUI scoreUI;
	[SerializeField]
	ScoreSaveData scoreData;

	public UnityEvent OnCoinBonusReach;

	int score;
	int CoinCount;
	float Timer = 0;
	
	GameManager GM;

	public void Start()
	{
		GM = GameManager.instance;
	}

	public void Update()
	{
		if(!GM.OnPause)
		{
			ScoreIncrmentation();
		}

	}

	public void SetScore(int value)
	{
		score = value;
	}
	public void ScoreIncrmentation()
	{
		if (Timer <= 1)
		{
			Timer += (Time.deltaTime / ScoreIncrementalTime);
		}
		else
		{
			Timer = 0;
			AddScore(1);
		}
	}

	public void AddScore(int value)
	{
		score += (value);
		UpdateScore();
	}

	public void AddCoin(int value)
	{
		CoinCount += (value);
		ComputeCoinModulo();
		UpdateCoinCount();
	}

	public void ComputeCoinModulo()
	{
		if (CoinCount % ScoreBonusReach == 0)
		{
			OnCoinBonusReach.Invoke();
		}
	}

	public void AddScoreByMultiplicator(int value)
	{
		AddScore(value * Multiplicator);
	}

	public int GetScore()
	{
		return score;
	}
	public int GetCoinCount()
	{
		return CoinCount;
	}
	public int GetMultiplicator()
	{
		return Multiplicator;
	}

	public void ResetScore()
	{
		score = 0;
		CoinCount = 0;
		UpdateScore();
		UpdateCoinCount();
	}

	public void ResetMultiplicator()
	{
		Multiplicator = 0;
		UpdateMultiplicator();
	}

	public void SetMultiplicator(int NewMultiplicator)
	{
		Multiplicator = NewMultiplicator;
		UpdateMultiplicator();
	}



	public void UpdateScore()
	{
		scoreUI.SetScore(GetScore());
	}

	public void UpdateCoinCount()
	{
		scoreUI.SetCoinCount(GetCoinCount());
	}

	public void UpdateMultiplicator()
	{
		scoreUI.SetMultiplicator(GetMultiplicator());
	}

	public void SavePlayerProgress()
	{
		SaveScore();
		SaveCoin();
	}

	void SaveScore()
	{
		scoreData.SaveHightScore(GetScore());
	}
	
	void SaveCoin()
	{
		scoreData.AddCoinCount(CoinCount);
	}
}
