using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
	public float speed;
	public float XOffsetIntensity;
	public int LaneID = 2;
	public Transform[] LanePosition;


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
	public Collider collider;

	public Transform CarTransform;

	bool GravityState;
	bool IsStraffing;
	public bool OnGround;
	public CarParticleEmmiter CarParticleEmmiter;

	public AudioClip SkiddingSound;
	public AudioClip OnAirStraff;
	public AudioClip JumpSound;
	public AudioSource SoundSource;

	public void Start()
	{
		ResetPosition();
	}

	public void Update()
	{
	  OnGround = Physics.CheckBox(collider.bounds.center, collider.bounds.extents + Vector3.up, new Quaternion(), GroundLayer);
	}

	public void ResetPosition()
	{
		transform.position = new Vector3(LanePosition[2].position.x, 1.9f,transform.position.z);
		CarTransform.localPosition = new Vector3(LanePosition[2].position.x,CarTransform.localPosition.y,CarTransform.localPosition.z);
		LaneID = 2;
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

	
	public void OnTouchingGround()
	{
		SoundSource.Play();
	}


	public void Straff(int direction)
	{
		if (!IsStraffing)
		{
			LaneID += direction;

			LaneID = Mathf.Clamp(LaneID, 0, 4);

			Vector3 FinalDestination = new Vector3(LanePosition[LaneID].position.x, CarTransform.position.y, CarTransform.position.z);
			CarParticleEmmiter.PlaySmokeParticle();
			StartCoroutine(SmoothSwap(FinalDestination));
		}
	}

	//public bool IsGrounded()
	//{
		
	//}

	public void Jump()
	{
		if (OnGround)
		{
			SoundSource.PlayOneShot(JumpSound);
			RB.AddForce(Vector3.up * jumpForce);
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

	public void PlayStraffSound()
	{
		if(OnGround)
		{
			SoundSource.PlayOneShot(OnAirStraff);
			SoundSource.PlayOneShot(SkiddingSound);
		}
		else
		{
			SoundSource.PlayOneShot(OnAirStraff);
		}
	}

	IEnumerator SmoothSwap(Vector3 Destination)
	{
		PlayStraffSound();
		IsStraffing = true;
		RB.useGravity = false;
		Vector3 OriginPos = CarTransform.position;
		for(float  i = 0; i < 1; i += Time.deltaTime / SwapDuration)
		{
			CarTransform.position = Vector3.Lerp(new Vector3(OriginPos.x,CarTransform.position.y, OriginPos.z), new Vector3(Destination.x,CarTransform.position.y,Destination.z),curve.Evaluate(i));
			yield return null;
		}
		CarTransform.position = Vector3.Lerp(OriginPos, new Vector3(Destination.x, CarTransform.position.y, Destination.z), 1);
		RB.useGravity = true;
		IsStraffing = false;
	}

	


}
