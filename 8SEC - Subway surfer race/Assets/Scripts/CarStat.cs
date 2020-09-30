using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStat : MonoBehaviour
{

	public Rigidbody RB;
	CarController carController;
	public bool IsDead;
	public GameObject Car;
	public GameOverUI UIGameOver;
	public Score score;
	public Collider collider;
	public void Start()
	{
		//RB = GetComponent<Rigidbody>();
		carController = GetComponent<CarController>();
	}


	public void InitCar()
	{
		RB.useGravity = true;
		score.Multiplicator = 1;
	}

	public void Respawn()
	{
		Car.gameObject.SetActive(true);
		Car.transform.position = transform.position;
		RB.useGravity = true;
		carController.LaneID = 2;
	
		score.Multiplicator = 1;
		collider.enabled = true;
		RB.useGravity = true;
		IsDead = false;
	}

	public void KillCar()
	{
		Car.gameObject.SetActive(false);
		UIGameOver.EnableUIGameOver();
		score.Multiplicator = 0;
		collider.enabled = false;
		RB.useGravity = false;
		RB.velocity = Vector3.zero;
		IsDead = true;
	}
}
