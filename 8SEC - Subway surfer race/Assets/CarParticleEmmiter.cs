using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarParticleEmmiter : MonoBehaviour
{
    public List<ParticlePlayer> SmokeParticle = new List<ParticlePlayer>();
    public ParticlePlayer ExplosionFX;
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
        ExplosionFX.CallParticlePlay();
	}
}
