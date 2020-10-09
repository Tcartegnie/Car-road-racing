using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{

	public CarController PlayerCar;
	public CarStat PlayerStat;
	public Vector2 SwipeSensitivity;
	public CarCinematiqueMovement carCinematiqueMovement;
	GameManager GM;

	public void Start()
	{
		GM = GameManager.instance;
	}

	public bool AccelerationEnable;

	public void Update()
	{
		if (!GM.OnPause)
		{
			if (Input.GetKeyUp(KeyCode.RightArrow))
			{
				PlayerCar.Straff(1);
			}

			if (Input.GetKeyUp(KeyCode.LeftArrow))
			{
				PlayerCar.Straff(-1);
			}

			if (AccelerationEnable == true)
			{
				PlayerCar.MoveOnForward(1);
			}


			if (Input.GetKeyDown(KeyCode.Space))
			{
				PlayerCar.Jump();
			}
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			carCinematiqueMovement.CallTransition();
		}
	}

	
	public void OnRespawnButtonPressed()
	{
		RespawnCar();
	}

	void RespawnCar()
	{
		if (!GM.OnPause)
		{
			PlayerCar.gameObject.SetActive(true);
			PlayerStat.Respawn();
		}
	}

	public void Swipe(float direction)
	{
		if (!GM.OnPause)
		{
			PlayerCar.Straff((int)direction);
		}
	}

	public void CallJump()
	{
		if (!GM.OnPause)
		{
			PlayerCar.Jump();
		}
	}

}
 