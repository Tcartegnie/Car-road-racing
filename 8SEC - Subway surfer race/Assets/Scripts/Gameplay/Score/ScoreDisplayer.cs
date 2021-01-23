using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour
{

    public ScoreSaveData saveData;

	public Text HightScoreDisplay;
	public Text CoinCountDisplay;

	public void Start()
	{
		RefreshScore();
	}

	public void RefreshScore()
	{
		DisplayHigtScore();
		DisplayCoinCount();
	}

	public void DisplayHigtScore()
	{
		HightScoreDisplay.text = saveData.GetHigtScore().ToString();
	}

	public void DisplayCoinCount()
	{
		CoinCountDisplay.text = saveData.GetCoinValue().ToString();
	}
}
