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
		SaveVolume(value);
	}

	public void OnValuechanged(float value)
	{
		//SaveVolume(value);
	}

	// Start is called before the first frame update
	void Start()
    {
		SetSFXVolume();
	}

	void SaveVolume(float value)
	{
		SetSFXVolume();
		SaveSFXVolume(value);
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
