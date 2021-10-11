using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject : MonoBehaviour
{


	GameManager GM;

	public float RotationSpeed;
	public Transform ObjetTR;
	public MovingObject movingObj;
	public float TravellingTime;
	public float ObjectHeight;
	public float TimeOnPlayerTop;
	public AudioClip sound;
	public AudioSource Audiosource;
	public string ObjectName;
	public Rigidbody RB;
	public Collider collider;
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
		RB.useGravity = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (movingObj != null)
			{
				movingObj.CanMove = false;
			}
			RB.constraints = RigidbodyConstraints.FreezeAll;
			DiseableGravity();
			StartCoroutine(TravelToTarget(other.transform));
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

	IEnumerator TravelToTarget(Transform other)
	{
		if (collider != null)
		{
			collider.enabled = false;
		}
		transform.position = other.position + (Vector3.up * ObjectHeight);
		transform.SetParent(other,true);
		UseBonus(other.gameObject);
		yield return new WaitForSeconds(TimeOnPlayerTop);
		RemoveItem();
	}

	public void OnCollisionEnter(Collision collision)
	{
		GetComponent<MovingObject>().speed = 60.0f;
	}

}
