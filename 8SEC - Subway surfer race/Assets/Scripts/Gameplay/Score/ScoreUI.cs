using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreUI : MonoBehaviour
{
	public Text ScoreDisplay;
	public Text MultiplicatorDisplay;
	public Text CoinCountDisplay;
	public void SetMultiplicator(int value)
	{
		MultiplicatorDisplay.text = "x"+value.ToString();
	}
	public void SetScore(int value)
	{
		ScoreDisplay.text = value.ToString();
	}
	public void SetCoinCount(int value)
	{
		CoinCountDisplay.text = value.ToString();
	}
}
