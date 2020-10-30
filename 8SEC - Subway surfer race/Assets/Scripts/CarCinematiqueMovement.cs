using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCinematiqueMovement : MonoBehaviour
{
    public float TransitionDuration;
	public Transform Start;
	public Transform Car;
	public Transform EndPosition;
	public AnimationCurve Transition;
   public void CallTransition()
	{
		StartCoroutine(CarTransition());
	}

    IEnumerator CarTransition()
	{
		Car.position = Start.position;
		Vector3 FinalPosition = EndPosition.position;
        for(float i = 0;i < 1; i+= Time.deltaTime / TransitionDuration)
		{
			Car.position = Vector3.Lerp(Start.position, FinalPosition, i);
			yield return null;
		}
		Car.position = Vector3.Lerp(Start.position, FinalPosition, 1);
	}
}
