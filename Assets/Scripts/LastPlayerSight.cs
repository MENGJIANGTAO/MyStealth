﻿using UnityEngine;
using System.Collections;

public class LastPlayerSight : MonoBehaviour {


    public Vector3 position = new Vector3(1000f, 1000f, 1000f);
    public Vector3 resetPosition = new Vector3(1000f, 1000f, 1000f);

	public float lightHighIntensity = .25f;
	public float lightLowIntensity = 0f;

	public float fadeSpeed = 7f;
    public float musicFadeSpeed = 1f;

	private AlarmLight alarmScript;
	private Light mainLight;

	private AudioSource music;
    private AudioSource panicAudio;
    private AudioSource[] sirens;

	private const float muteVolume = 0f;
	private const float normalVolume = .8f;

    void Awake() {
		alarmScript = GameObject.FindWithTag (Tags.AlarmLight).GetComponent<AlarmLight> ();
		mainLight = GameObject.FindWithTag (Tags.MainLight).GetComponent<Light> ();
		music = GetComponent<AudioSource> ();
		panicAudio = transform.Find ("secondary_music").GetComponent<AudioSource> ();
		GameObject[] sirenGameObjects = GameObject.FindGameObjectsWithTag (Tags.Siren);
		sirens = new AudioSource[sirenGameObjects.Length];
		for (int i = 0; i<sirens.Length; i++) {
			sirens[i] = sirenGameObjects[i].GetComponent<AudioSource>();
		}
    }
	
	// Update is called once per frame
	void Update () {
		SwitchAlarms();
		MusicFading();
	}

    void MusicFading() {

        if (position != resetPosition) {
			music.volume = Mathf.Lerp(music.volume, muteVolume, musicFadeSpeed * Time.deltaTime);
			panicAudio.volume = Mathf.Lerp(panicAudio.volume, normalVolume, musicFadeSpeed * Time.deltaTime);
        } else {
			music.volume = Mathf.Lerp(music.volume, normalVolume, musicFadeSpeed * Time.deltaTime);
			panicAudio.volume = Mathf.Lerp(panicAudio.volume, muteVolume, musicFadeSpeed * Time.deltaTime);
        }
        
    }

    void SwitchAlarms() {
		alarmScript.alarmOn = (position != resetPosition);
		float newIntensity;
		if (position != resetPosition) {
			newIntensity = lightLowIntensity;
		} else {
			newIntensity = lightHighIntensity;
		}
		mainLight.intensity = Mathf.Lerp (mainLight.intensity, newIntensity, fadeSpeed * Time.deltaTime);
		for (int i = 0; i<sirens.Length; i++) {
			if(position != resetPosition && !sirens[i].isPlaying)
				sirens[i].Play();
			else if (position == resetPosition)
				sirens[i].Stop();
		}
    }
}