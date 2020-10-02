using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarParticleEmmiter : MonoBehaviour
{
	public Transform carTransform;
    public List<ParticlePlayer> SmokeParticle = new List<ParticlePlayer>();
    public ParticlePlayer ExplosionFX;
	ParticlePlayer CurrentparticlePlayer;
     // Start is called before the first frame update
    
    public void PlaySmokeParticle()
	{
        for(int i =0; i < SmokeParticle.Count;i++)
		{
            SmokeParticle[i].CallParticlePlay();
        }
	}

    public void PlayExplostion()
	{
		StartCoroutine(PlayerGameOver());
	}

	public IEnumerator PlayerGameOver()
	{
		CurrentparticlePlayer = Instantiate(ExplosionFX, carTransform.position, new Quaternion());
		yield return StartCoroutine(CurrentparticlePlayer.PlayOneShoot());
	}
}
