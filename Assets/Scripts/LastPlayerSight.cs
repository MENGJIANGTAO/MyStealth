using UnityEngine;
using System.Collections;

public class LastPlayerSign : MonoBehaviour {


    public Vector3 playerPosition = new Vector3(1000f, 1000f, 1000f);
    public Vector3 resetPosition = new Vector3(1000f, 1000f, 1000f);


    public float soundFadeSpeed = .5f;

    private AudioSource backmusic;
    private AudioSource[] alarm;

    void Awake() {
        backmusic = transform.FindChild(Tags.BkMusic).GetComponent<AudioSource>();
        GameObject[] alarmObjects = GameObject.FindGameObjectsWithTag(Tags.Siren);
        alarm = new AudioSource[alarmObjects.Length];
        for (int i = 0; i < alarm.Length; i++) {
            alarm[i] = alarmObjects[i].GetComponent<AudioSource>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        switchSound();
	}

    void switchSound() {

        for (int i = 0; i < alarm.Length; i++) {
            if (playerPosition != resetPosition && !alarm[i].isPlaying) {
                alarm[i].Play();
            }
            else if (playerPosition == resetPosition) {
                alarm[i].Stop();
            }
        }
        if (playerPosition != resetPosition) {
            GetComponent<AudioSource>().volume = Mathf.Lerp(GetComponent<AudioSource>().volume, 0f, soundFadeSpeed * Time.deltaTime);
            backmusic.volume = Mathf.Lerp(backmusic.volume, 1f, soundFadeSpeed * Time.deltaTime);
        } else {
            GetComponent<AudioSource>().volume = Mathf.Lerp(GetComponent<AudioSource>().volume, 1f, soundFadeSpeed * Time.deltaTime);
            backmusic.volume = Mathf.Lerp(backmusic.volume, 0f, soundFadeSpeed * Time.deltaTime);
        }
        
    }

    void switchLight() {
           
    }
}
