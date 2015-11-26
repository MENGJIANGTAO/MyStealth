using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenFadeInOut : MonoBehaviour {

	public float fadeSpeed = 0.5f;
	public bool startScene = true;
	private RawImage rawImage = null;

	void Awake(){
		rawImage = GetComponent<RawImage> ();
	}

	void Update () {
		if (startScene) {
			StartScene();
		}
	}

	void FadeToClear(){
		rawImage.color = Color.Lerp (rawImage.color, Color.clear, fadeSpeed * Time.deltaTime);
	}

	void FadeToBlack(){
		rawImage.color = Color.Lerp (rawImage.color, Color.black, fadeSpeed * Time.deltaTime);
	}

	public void StartScene(){
		FadeToClear ();
		if (rawImage.color.a <= 0.05f) {
			rawImage.color = Color.clear;
			rawImage.enabled = false;
			startScene = false;
		}
	}

	public void EndScene(){
		rawImage.enabled = true;
		FadeToBlack ();
		if (rawImage.color.a >= 0.95f) {
			Application.LoadLevel(0);
		}
	}
}
