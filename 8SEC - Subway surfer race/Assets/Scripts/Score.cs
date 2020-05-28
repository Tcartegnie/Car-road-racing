using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
	public PauseMenu menu;
	int score;
	public int Multiplicator = 0;
	public ScoreUI scoreUI;
	float Timer = 0;
	public float ScoreIncrementalTime;

	GameManager GM;

	public void Start()
	{
		GM = GameManager.instance;
	}

	public void Update()
	{
		if(!GM.OnPause)
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
	}

	public void AddScore(int value)
	{
		score += (value * Multiplicator);
		UpdateScore();
	}

	public int GetScore()
	{
		return score;
	}

	public void ResetScore()
	{
		score = 0;
	}

	public void UpdateScore()
	{
		scoreUI.SetScore(GetScore());
	}
}
