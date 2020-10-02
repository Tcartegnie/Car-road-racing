using JetBrains.Annotations;
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
	public CarParticleEmmiter CarParticleEmmiter;
	public ParticlePlayer Explosion;
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
		GameManager.instance.OnPause = false;
		Car.gameObject.SetActive(true);
		Car.transform.position = transform.position;
		RB.useGravity = true;
		carController.LaneID = 2;
	
		score.Multiplicator = 1;
		collider.enabled = true;
		RB.useGravity = true;
		IsDead = false;
	}

	public IEnumerator PlayerGameOver()
	{
		GameManager.instance.OnPause = true;
		KillCar();
		yield return StartCoroutine(CarParticleEmmiter.PlayerGameOver());
		EnableEndGameScreen();


	}
	
	public void CallKillCar()
	{
		StartCoroutine(PlayerGameOver());
	}

	public void KillCar()
	{
		Car.gameObject.SetActive(false);

		score.Multiplicator = 0;
		collider.enabled = false;
		RB.useGravity = false;
		RB.velocity = Vector3.zero;
		IsDead = true;
	}

	public void EnableEndGameScreen()
	{
		UIGameOver.EnableUIGameOver();
	}
}
