using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
	public float speed;
	public float XOffsetIntensity;

	public int LaneID = 2;
	public int[] LanePosition;


	public float ZLandmarkPosition = 0;

	public float ZOffset;
	float ZOffsetIntensity = 0;

	public float YOffset;

	public float SwapDuration;
	public float JumpDuration;
	public Rigidbody RB;
	public float jumpForce;
	public float AirTime;
	public AnimationCurve curve;

	public LayerMask GroundLayer;
	public BoxCollider collider;
	public Transform Collider;

	public Transform CarTransform;

	bool GravityState;

	public void ResetPosition()
	{
		Collider.position = new Vector3(0, 1, 0);
		CarTransform.position = new Vector3(0, 1, 0);
	}

	public void MoveOnForward(float direction)
	{

		ZOffsetIntensity = (direction * (Time.deltaTime * speed));
		transform.position +=Vector3.forward * ZOffsetIntensity;

		if((transform.position.z - ZLandmarkPosition) > ZOffset)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, ZOffset);
		}
		else if ((transform.position.z - ZLandmarkPosition) < -ZOffset)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, -ZOffset);
		}
	}



	public void Straff(int direction)
	{
		LaneID += direction;

		LaneID = Mathf.Clamp(LaneID, 0, 4);

		Vector3 FinalDestination = new Vector3(LanePosition[LaneID] * XOffsetIntensity, Collider.position.y, Collider.position.z);
		Collider.position = FinalDestination;
	//	transform.position = FinalDestination;
		StartCoroutine(SmoothSwap(FinalDestination));

	}

	public bool IsGrounded()
	{
		return Physics.CheckCapsule(collider.bounds.center, new Vector3(collider.bounds.center.x, collider.bounds.center.y, collider.bounds.center.z), 1f, GroundLayer);
	}

	public void CallJump()
	{
		if (IsGrounded())
		{
		//	Collider.position =  new Vector3(Collider.position.x, Collider.position.y, Collider.position.z) + Vector3.up * YOffset;
			StartCoroutine(Jump());
		}
	}

	public void Pause()
	{
		GravityState = RB.useGravity;
		RB.useGravity = false;
		RB.velocity = Vector3.zero;
	}

	public void UnPause()
	{
		RB.useGravity = GravityState;
	}

	IEnumerator Jump()
	{
		Vector3 OriginPos = CarTransform.position;
		RB.useGravity = false;
		for (float i = 0; i < 1; i += Time.deltaTime / JumpDuration)
		{
			Vector3 result = Vector3.Lerp(OriginPos, new Vector3(CarTransform.position.x, CarTransform.position.y, CarTransform.position.z) + Vector3.up * YOffset, curve.Evaluate(i));
			Collider.position = result;
			CarTransform.position = result;
			yield return null;
		}
		Collider.position = Vector3.Lerp(OriginPos, new Vector3(CarTransform.position.x, CarTransform.position.y, CarTransform.position.z) + Vector3.up * YOffset, 1);
		CarTransform.position = Vector3.Lerp(OriginPos, new Vector3(CarTransform.position.x, CarTransform.position.y, CarTransform.position.z) + Vector3.up * YOffset, 1);
		yield return StartCoroutine(Levitate());
	}

	IEnumerator Levitate()
	{
		yield return new WaitForSeconds(AirTime);
		RB.useGravity = true;
	}


	IEnumerator SmoothSwap(Vector3 Destination)
	{
		Vector3 OriginPos = CarTransform.position;
		for(float  i = 0; i < 1; i += Time.deltaTime / SwapDuration)
		{
			CarTransform.position = Vector3.Lerp(OriginPos,Destination,curve.Evaluate(i));
			yield return null;
		}
		CarTransform.position = Vector3.Lerp(OriginPos, Destination, 1);
	}




}
