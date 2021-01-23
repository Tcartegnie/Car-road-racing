using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCollider : MonoBehaviour
{
	public Score score;
	public int ScorePerBounce;
	public CarStat carstate;
	bool Invulnerable;

	void OnTriggerEnter(Collider other)
	{
		CallCollision(other);
	}

	void SetInvulnerability(bool value)
	{
		Invulnerable = value;
	}
	public void TurnInvulnerabilityOn()
	{
		SetInvulnerability(true);
	}
	public void TurnInvulnerabilityOff()
	{
		SetInvulnerability(false);
	}

	public void CallCollision(Collider other)
	{
		if (Invulnerable)
		{
			other.GetComponentInChildren<BounceScript>().Bounce();
			score.AddScore(ScorePerBounce);
		}
		else
		{
			carstate.CallKillCar();
		}
	}
}
