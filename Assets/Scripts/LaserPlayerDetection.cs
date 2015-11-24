using UnityEngine;
using System.Collections;

public class LaserPlayerDetection : MonoBehaviour {


	private GameObject _player;
	private LastPlayerSight _lastPlayerSight;

	// Use this for initialization
	void Start () {
		_player = GameObject.FindWithTag (Tags.Player);
		_lastPlayerSight = GameObject.FindWithTag (Tags.GameController).GetComponent<LastPlayerSight> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other){
		if (GetComponent<Renderer> ().enabled) {
			if(other.gameObject == _player){
				_lastPlayerSight.position = other.transform.position;
			}
		}
	}
}
