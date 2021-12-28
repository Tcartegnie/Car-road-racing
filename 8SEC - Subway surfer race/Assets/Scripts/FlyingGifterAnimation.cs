using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingGifterAnimation : MonoBehaviour
{

	public Animator TurnAround;


	public void PlayTurnAround()
	{
		TurnAround.SetTrigger("Rotation");
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
