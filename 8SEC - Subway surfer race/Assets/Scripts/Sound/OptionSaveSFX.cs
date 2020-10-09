using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSaveSFX : MonoBehaviour, ISaveComponent
{
    public SoundHandler soundHandler;
	public AudioSource SoundTest;
	public void OnSliderReleasde(float value)
	{
		SoundTest.Play();
	}

	public void OnValuechanged(float value)
	{
		SaveSFXVolume(value);
		SetSFXVolume();
	}

	// Start is called before the first frame update
	void Start()
    {
		SetSFXVolume();
	}


	public void SetSFXVolume()
	{
		soundHandler.SetSFXVolume();
	}
	public void SaveSFXVolume(float volume)
	{
		soundHandler.SaveSFXVolume(volume);
	}

	
}
