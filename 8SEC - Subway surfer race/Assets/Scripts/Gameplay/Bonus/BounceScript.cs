using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScript : MonoBehaviour
{
	public Rigidbody RB;

	public Collider CarCollider;
	public Collider PlateFormeCollider;
	[Space]
	public float BackWardStrenght;
	public float LateralStrenght;
	public float VerticalStrenght;
	public float EjectionStrenght;
	public float RotationStrenght;
	[Space]
	public AudioSource audioSource;
	public AudioClip CrashSound;
	public AudioClip FlySound;
	public AudioClip HornSound;
	public void Bounce()
	{
		CarCollider.enabled = false;
		PlateFormeCollider.enabled = false;
		RB.constraints = RigidbodyConstraints.None;
		RB.AddForce(transform.forward * (BackWardStrenght * EjectionStrenght) + (transform.up * (Random.Range(0,VerticalStrenght) * EjectionStrenght) + (transform.right * Random.Range(-LateralStrenght * EjectionStrenght, LateralStrenght * EjectionStrenght))));
		AddRandomTorque();
		PlaySounds();
	}

	public void PlaySounds()
	{
		audioSource.PlayOneShot(CrashSound);
		audioSource.PlayOneShot(FlySound);
		audioSource.PlayOneShot(HornSound);
	}

	public void AddRandomTorque()
	{
		if (Random.Range(0, 2) == 1)
		{
			RB.AddTorque(transform.right * RotationStrenght);
		}

		if (Random.Range(0, 2) == 1)
		{
			RB.AddTorque(transform.up * RotationStrenght);
		}

		if (Random.Range(0, 2) == 1)
		{
			RB.AddTorque(transform.forward * RotationStrenght);
		}
	}
}
