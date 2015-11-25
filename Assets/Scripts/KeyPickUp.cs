using UnityEngine;
using System.Collections;

public class KeyPickUp : MonoBehaviour {

	public AudioClip _keyGrab;
	private GameObject _player;
	private PlayerInventory _playerInventory;

	void Awake(){
		_player = GameObject.Find ("player");
		_playerInventory = _player.GetComponent<PlayerInventory> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject == _player) {
			AudioSource.PlayClipAtPoint(_keyGrab,transform.position);
			_playerInventory.hasKey = true;
			Destroy(gameObject);
		}
	}
}
