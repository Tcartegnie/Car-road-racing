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
		gameObject.SetActive(false);
	}

	IEnumerator TravelToTarget(GameObject other)
	{
		transform.position = other.transform.position + (Vector3.up * ObjectHeight);
		transform.SetParent(other.transform,true);
		UseBonus(other);
		yield return new WaitForSeconds(TimeOnPlayerTop);
	
	}


}
