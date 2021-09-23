using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public float timer;
	// Start is called before the first frame update
	public void Update()
	{
		CountMultiplicatorTimer();
	}

	void CountMultiplicatorTimer()
	{
		if (CheckMultipicatorTimer())
		{
			timer -= Time.deltaTime;
		}
	}

	public void AddTimerDuration(float Duration)
	{
		timer += Duration;
	}

	bool CheckMultipicatorTimer()
	{
		if (timer <= 0)
		{
			OnTimerNull();
			return false;
		}
		return true;
	}

	public virtual void OnTimerNull(){}




}
