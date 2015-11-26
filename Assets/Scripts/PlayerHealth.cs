using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float health = 100f;
	public float resetAfterDeathTime = 5f;
	public AudioClip deathClip;

	private Animator deathanim;
	private PlayerMovement playerMovement;
	private HashIDs hash;
	private ScreenFadeInOut screenFadeInOut;
	private LastPlayerSight lastPlayerSighting;
	private float timer;
	private bool playerDead;


	void Awake(){
		deathanim = GetComponent<Animator> ();
		playerMovement = GetComponent<PlayerMovement> ();;
		hash = GameObject.FindWithTag (Tags.GameController).GetComponent<HashIDs> ();
		screenFadeInOut = GameObject.FindWithTag (Tags.Fader).GetComponent<ScreenFadeInOut> ();
		lastPlayerSighting = GameObject.FindWithTag (Tags.GameController).GetComponent<LastPlayerSight> ();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			if(!playerDead){
				PlayerDying();
			}else{
				PlayerDead();
				levelReset();
			}
		}
	}

	void PlayerDying(){
		playerDead = true;
		deathanim.SetBool (hash.deadBool, playerDead);
		AudioSource.PlayClipAtPoint (deathClip, transform.position);
	}

	void PlayerDead(){
		if (deathanim.GetCurrentAnimatorStateInfo (0).shortNameHash == hash.dyingState) {
			deathanim.SetBool(hash.deadBool,false);
			deathanim.SetFloat(hash.speedFloat,0f);
			playerMovement.enabled = false;
			lastPlayerSighting.position = lastPlayerSighting.resetPosition;
			GetComponent<AudioSource>().Stop();
		}
	}

	void levelReset(){
		timer += Time.deltaTime;
		if (timer >= resetAfterDeathTime) {
			screenFadeInOut.EndScene();
		}
	}

	public void TakeDamage(float amout){
		health -= amout;
	}
}
