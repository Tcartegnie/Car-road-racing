using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chrono : MonoBehaviour
{
	public float TimerValue = 0.0f;
    bool ChronoEnable = false;
	float CurrentTimeValue = 0.0f;

	public delegate void ChronoEvent();
	public ChronoEvent OnEndChrono;

	public Chrono(float timerValue)
	{
		TimerValue = timerValue;
	}

	public void StartChrono()
	{
		CurrentTimeValue = TimerValue;
		ChronoEnable = true;
	}

	public void Update()
	{
		PlayChrono();
	}

	public void PlayChrono()
	{
		if(ChronoEnable)
		{
			CurrentTimeValue -= Time.deltaTime;
		}
		if(CurrentTimeValue <= 0.0F)
		{
			EndChrono();
		}
	}

	public void EndChrono()
	{
		ChronoEnable = false;
		OnEndChrono();
	}

}
