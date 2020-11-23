using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public ScoreSaveData data;
    public Score score;

    public EndGameUI UI;
	public InGameUI IGUI;

	public float CoolDownAfterCount;

	public void PlayDisplayScore()
	{
		if (data.CheckHightScore(score.GetScore()))
		{
			UI.EnablHigthScoreRect();
			UI.SetHightScore(score.GetScore());
		}
		StartCoroutine(ComputeCoins(data.GetCoinValue(),score.GetCoinCount()));
	}

	public void EnableMainMenu()
	{
		UI.DiseableHightScoreRect();
		UI.DiseableRect();
		IGUI.OnButtonReturnPressed();
	}

	public IEnumerator ComputeCoins(int totalCoin, int ScoreCoin)
	{ 
		int TotalCoin = totalCoin;
		int CurrentCoin = ScoreCoin;
        for(int i = CurrentCoin; i > 0; i--)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			TotalCoin += 1;
			CurrentCoin -= 1;
			UI.SetTotalScoreCount(TotalCoin);
			UI.SetGameScoreCount(CurrentCoin);
			//PlayCoinSound
		}
		yield return new WaitForSeconds(CoolDownAfterCount);
		EnableMainMenu();
	}
}
