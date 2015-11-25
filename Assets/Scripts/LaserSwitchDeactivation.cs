﻿using UnityEngine;
using System.Collections;

public class LaserSwitchDeactivation : MonoBehaviour {


	public GameObject player;
	public Material unlockedMat;
	public GameObject laser;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LaserDeactivation(){
		laser.SetActive (false);
		Renderer screen = transform.Find ("prop_switchUnit_screen").GetComponent<Renderer> ();
		screen.material = unlockedMat;
		GetComponent<AudioSource> ().Play ();
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject == player) {
			if(Input.GetButton("Switch")){
				LaserDeactivation();
			}
		}
	}
}
