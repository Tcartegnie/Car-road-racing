using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCollider : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{

			other.GetComponent<CarStat>().KillCar();
			//other.gameObject.SetActive(false);
		}
	}

}
