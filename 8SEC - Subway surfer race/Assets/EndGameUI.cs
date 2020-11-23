using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    public GameObject HightScoreRect;
    public GameObject ProgressRect;
    public Text HightScoreCount;
    public Text GameScoreCount;
    public Text TotalScoreCount;

    public void EnableRect()
	{
        ProgressRect.SetActive(true);
    }

    public void DiseableRect()
	{
        ProgressRect.SetActive(false);
	}
        
  

    public void EnablHigthScoreRect()
	{
        HightScoreRect.SetActive(true);
	}

    public void DiseableHightScoreRect()
	{
        HightScoreRect.SetActive(false);
    }

    public void SetHightScore(int value)
    {
        HightScoreCount.text = value.ToString();
    }

    public void SetGameScoreCount(int value)
	{
        GameScoreCount.text = value.ToString();

    }

    public void SetTotalScoreCount(int value)
    {
        TotalScoreCount.text = value.ToString();

    }


}
