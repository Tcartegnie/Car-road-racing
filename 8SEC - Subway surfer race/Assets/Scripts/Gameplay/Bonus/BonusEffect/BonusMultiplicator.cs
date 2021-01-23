using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMultiplicator : Bonus
{
	public Score score;

	public float MultiplicatorTimer = 0;
	public  void CallBonus(int Multiplication, float duration)
	{
		score.SetMultiplicator(Multiplication);
		AddTimerDuration(duration);
	}

	public override void OnTimerNull()
	{
		base.OnTimerNull();
		score.ResetMultiplicator();
	}

}
