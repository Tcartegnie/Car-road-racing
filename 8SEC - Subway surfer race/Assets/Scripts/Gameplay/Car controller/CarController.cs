using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
	public float speed;
	public float XOffsetIntensity;
	public int LaneID = 2;



	public float ZLandmarkPosition = 0;

	public float ZOffset;
	float ZOffsetIntensity = 0;

	public float YOffset;

	
	public float JumpDuration;
	public Rigidbody RB;
	public float jumpForce;
	public float AirTime;

	public LayerMask GroundLayer;
	public Collider collider;



	bool GravityState;
	bool IsStraffing;
	public bool OnGround;
	public CarParticleEmmiter CarParticleEmmiter;

	public AudioClip SkiddingSound;
	public AudioClip OnAirStraff;
	public AudioClip JumpSound;
	public AudioSource SoundSource;

	public MainMenuUI menu;

	public SwapLine swap;

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
		LaneID = 2;
	 StartCoroutine(swap.SwapToLine(LaneID));
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
		if (!IsStraffing && !menu.IsInMainMenu)
		{
			LaneID += direction;
			LaneID = Mathf.Clamp(LaneID, 0, 4);
			CarParticleEmmiter.PlaySmokeParticle();
			StartCoroutine(SmoothSwap(LaneID));
		}
	}

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

	IEnumerator SmoothSwap(int LineID)
	{
		PlayStraffSound();
		
		IsStraffing = true;
		RB.useGravity = false;

		yield return StartCoroutine(swap.SwapToLine(LineID));

		RB.useGravity = true;
		IsStraffing = false;
	}

	


}
