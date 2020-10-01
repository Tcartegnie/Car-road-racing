using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCollider : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{

			other.GetComponentInParent<CarStat>().CallKillCar();
			//other.gameObject.SetActive(false);
		}
	}

}
