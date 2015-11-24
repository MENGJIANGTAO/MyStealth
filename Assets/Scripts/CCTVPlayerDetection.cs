using UnityEngine;
using System.Collections;

public class CCTVPlayerDetection : MonoBehaviour {


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
		if (other.gameObject == _player) {
			Vector3 realPlayerPos = _player.transform.position - transform.position;
			RaycastHit hit;
			if(Physics.Raycast(transform.position,realPlayerPos,out hit)){
				if(hit.collider.gameObject == _player){
					_lastPlayerSight.position = _player.transform.position;
				}
			}
		}
	}
}
