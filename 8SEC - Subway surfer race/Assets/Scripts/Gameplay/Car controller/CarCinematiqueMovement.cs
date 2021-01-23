using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCinematiqueMovement : MonoBehaviour
{
    public float TransitionDuration;
	public Transform Start;
	public Transform Car;
	public Transform EndPositionIn;
	public Transform StartPositionOut;
	public Transform EndPositionOut;
	public AnimationCurve Transition;
	
   public void CallTransitionIn()
	{
		StartCoroutine(CarTransitionIn());
	}

	public void CallTransitionOut()
	{
		StartCoroutine(CarTransitionOut());
	}

	public void CallCompleteTransition()
	{
		StartCoroutine(CompleteTransition());
	}

	IEnumerator CompleteTransition()
	{
		yield return StartCoroutine(CarTransition(Start, StartPositionOut));
		yield return StartCoroutine(CarTransition(StartPositionOut,EndPositionOut));
	}

    IEnumerator CarTransition(Transform StartPosition,Transform ReachPosition)
	{
		Car.position = StartPosition.position;
		Vector3 start = StartPosition.position;
		Vector3 destination = ReachPosition.position;
        for(float i = 0;i < 1; i+= Time.deltaTime / TransitionDuration)
		{
			Car.position = Vector3.Lerp(start, destination, i);
			yield return null;
		}
		Car.position = Vector3.Lerp(start, destination, 1);
	}

	public IEnumerator CarTransitionIn()
	{
		yield return StartCoroutine(CarTransition(Start, EndPositionIn));
	}
	public IEnumerator CarTransitionOut()
	{
		yield return StartCoroutine(CarTransition(StartPositionOut, EndPositionOut));
	}
}
