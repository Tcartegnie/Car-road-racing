using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
	public float speed;
	public GameManager GM;
	public bool CanMove = true;
	// Update is called once per frame
	private void Start()
	{
		GM = GameManager.instance;
	}


	void Update()
    {
		if (CanMove)
		{
			MoveForward();
		}
    }

	public void MoveForward()
	{
		transform.position -= transform.forward * (Time.deltaTime * speed);
	}

}
