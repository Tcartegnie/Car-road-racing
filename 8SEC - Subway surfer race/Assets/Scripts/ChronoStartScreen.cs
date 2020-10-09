using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChronoStartScreen : MonoBehaviour
{

	public Text Chrono;
	public Text Announce;

	public RectTransform GoScreen;
	public float GoScreenTransitionTimer;
	public float GoScreenPause;
	public AudioSource StartSound;
	public void SeTChronoText(string text)
	{
		Chrono.text = text;
	}

	public void SeTAnnounceText(string text)
	{
		Announce.text = text;
	}

	public void TurnOn()
	{
		gameObject.SetActive(true);
	}
	public void TurnOff()
	{
		gameObject.SetActive(false);
	}


	public IEnumerator PlayGoScreenDisplay()
	{
		StartSound.Play();
		yield return (GoScreenDisplay());
		yield return new WaitForSeconds(StartSound.clip.length - GoScreenTransitionTimer);
		GoScreen.localScale = Vector3.zero;
		TurnOff();
	}

	 IEnumerator GoScreenDisplay()
	{
		GoScreen.localScale = Vector3.zero;
		for (float i = 0; i < 1;i +=  Time.deltaTime / GoScreenTransitionTimer )
		{
			GoScreen.localScale = new Vector3(i, i, i);
			yield return null;
		}
		GoScreen.localScale = Vector3.one;
	}


}
