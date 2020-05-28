using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreUI : MonoBehaviour
{
	
	public Text ScoreValue;
   
	public void SetScore(int value)
	{
		ScoreValue.text = value.ToString();
	}
}
