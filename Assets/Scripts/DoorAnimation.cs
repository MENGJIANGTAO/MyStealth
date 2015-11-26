using UnityEngine;
using System.Collections;

public class DoorAnimation : MonoBehaviour {


	public bool requireKey;
	public AudioClip doorSwitchClip;
	public AudioClip accessDeniedClip;

	private Animator anim;
	private HashIDs hash;
	private GameObject player;
	private PlayerInventory playerInventory;
	private bool open;

	void Awake(){
		anim = GetComponent<Animator> ();
		hash = GameObject.FindWithTag (Tags.GameController).GetComponent<HashIDs> ();
		player = GameObject.Find ("player");
		playerInventory = player.GetComponent<PlayerInventory> ();
		open = false;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool (hash.openBool, open);
		AudioSource audio = GetComponent<AudioSource> ();
		if (anim.IsInTransition (0) && !audio.isPlaying) {
			audio.clip = doorSwitchClip;
			audio.Play();
		}
	}

	void OnTriggerEnter(Collider other){
		AudioSource audio = GetComponent<AudioSource> ();

		if (other.gameObject == player) {
			if (requireKey) {
				if (playerInventory.hasKey)
					open = true;
				else {
					audio.clip = accessDeniedClip;
					audio.Play ();
				}
			} else {
				open = true;;
			}
		} else if (other.gameObject.tag == Tags.Enemy) {
			if(other is CapsuleCollider)
				open = true;;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject == player || (other.gameObject.tag == Tags.Enemy && other is CapsuleCollider)) {
			open = false;
		}
	}
}
