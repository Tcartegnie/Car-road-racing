using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject : MonoBehaviour
{


	GameManager GM;

	public float RotationSpeed;
	public Transform ObjetTR;
	Transform Target;
	public float TravellingTime;
	public float ObjectHeight;
	public float TimeOnPlayerTop;
	public AudioClip sound;
	public AudioSource Audiosource;
	public string ObjectName;
	public Rigidbody RB;

	void Update()
	{
		if (!GM.OnPause)

		{
			ObjetTR.Rotate(Vector3.up, RotationSpeed);
		}
		//transform.position += transform.forward * (Time.deltaTime * speed);
	}
	public void Start()
	{
		GM = GameManager.instance;
	}

	public void EnableGravity()
	{
		RB.useGravity = true;
	}

	public void DiseableGravity()
	{
		RB.useGravity = true;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Target = other.transform;
			StartCoroutine(TravelToTarget(Target.gameObject));
		}
	}


	public virtual void UseBonus(GameObject other)
	{
		Audiosource.PlayOneShot(sound);
	}

	void RemoveItem()
	{
		gameObject.SetActive(false);
	}

	IEnumerator TravelToTarget(GameObject other)
	{
		transform.position = other.transform.position + (Vector3.up * ObjectHeight);
		transform.SetParent(other.transform,true);
		UseBonus(other);
		yield return new WaitForSeconds(TimeOnPlayerTop);
		RemoveItem();
	}

	public void OnCollisionEnter(Collision collision)
	{
		GetComponent<MovingObject>().speed = 60.0f;
	}

}
