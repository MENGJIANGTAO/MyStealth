using UnityEngine;
using System.Collections;

public class LaserBlinking : MonoBehaviour {

	public float onTime;
	public float offTime;

	private float time;
	private Renderer laserRender;
	private Light laserLight;
	private BoxCollider laserCollider;

	void Awake(){
		laserRender = GetComponent<Renderer> ();
		laserLight = GetComponent<Light> ();
		laserCollider = GetComponent<BoxCollider> ();
		time = 0f;
	}
	// Use this for initialization
	void Start () {
	
	}

	void switchTrigger(){
		time = 0f;
		laserRender.enabled = !laserRender.enabled;
		laserLight.enabled = !laserLight.enabled;
		laserCollider.enabled = !laserCollider.enabled;
	}
	
	// Update is called once per frame
	void Update () {
		time+= Time.deltaTime;
		if (laserRender.enabled && time > onTime)
			switchTrigger ();
		if (!laserRender.enabled && time > offTime)
			switchTrigger ();
	}
}
