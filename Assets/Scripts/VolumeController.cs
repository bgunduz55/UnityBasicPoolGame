using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumeController : MonoBehaviour {

	private float volumeLevel = 1f;
	public Slider slider;
	private AudioSource audioSrc;
	// Use this for initialization
	void Start () {
		audioSrc = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		// Fetch Audio volume with volumeLevel
		audioSrc.volume = volumeLevel;
		slider.value = volumeLevel;
	}
	//This one called from slider and mute button
	public void setVolume(float vol) {
		volumeLevel = vol;
	}
	public void playAudioWithVolume(float volMultiplier) {
		audioSrc.volume = (volMultiplier/30) * volumeLevel;
		Debug.Log(audioSrc.volume);
		audioSrc.Play();
		//audioSrc.volume = volumeLevel;
	}
}
