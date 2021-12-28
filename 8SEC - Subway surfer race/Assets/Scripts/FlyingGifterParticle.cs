using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingGifterParticle : MonoBehaviour
{
	public List<ParticleSystem> particles;

	public void Start()
	{
		DiseableaParticle();
	}

	public void EnableParticle()
	{
		foreach(ParticleSystem particle in particles)
		{
			particle.Play();
		}
	}

	public void DiseableaParticle()
	{
		foreach (ParticleSystem particle in particles)
		{
			particle.Stop();
		}
	}


}
