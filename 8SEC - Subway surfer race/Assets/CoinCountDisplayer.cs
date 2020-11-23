using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCountDisplayer : MonoBehaviour
{
    public ScoreSaveData scoreSaveData;
    public Text CoinCountText;
    // Start is called before the first frame update
    public void UpdateScoreToDisplay()
	{
        CoinCountText.text = scoreSaveData.GetCoinValue().ToString();
	}
}
