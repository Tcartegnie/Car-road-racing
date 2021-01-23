using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateDisplayer : MonoBehaviour
{
	GameManager GM;
	public Text LifeText;

	public void UpdateLifeText()
	{
		LifeText.text = ":X " + GM.life;
	}

	// Update is called once per frame
	void Update()
    {
		UpdateLifeText();
    }

	private void Start()
	{
		GM = GameManager.instance;
	}
}
