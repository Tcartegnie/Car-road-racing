using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSoundPlayer : MonoBehaviour
{
    public AudioSource SoundSource;
    public SoundList list;

   public void PlayEngineSound()
	{
        PlaySound(list.GetEngineSound());
    }

    public void PlayStraffSound()
    {
        PlaySound(list.GetStraffSound());
    }

    public void PlayAirStraffSound()
    {
        PlaySound(list.GetAirStraffSound());
    }

    public void PlayJumpSound()
	{
		PlaySound(list.GetJumpSound());
	}

    private void PlaySound(AudioClip clip)
    {
        SoundSource.PlayOneShot(clip);
  
    }
}
