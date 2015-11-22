using UnityEngine;
using System.Collections;

public class AlarmLight : MonoBehaviour {

    public float fadespeed = 2.0f;
    public float highIntensity = 4.0f;
    public float lowIntensity = 0.5f;

    public float changeMargin = 0.2f;
    public bool alarmOn;

    private float targetIntensity;
    private Light alarmLight;

    void Awake() {
        alarmLight = GetComponent<Light>();
        alarmLight.intensity = 0f;
        targetIntensity = highIntensity;
    }

    void Update() {
        if (alarmOn){
            alarmLight.intensity = Mathf.Lerp(alarmLight.intensity, targetIntensity, fadespeed * Time.deltaTime);
            CheckTargetIntensity();
        }
        else {
            alarmLight.intensity = Mathf.Lerp(alarmLight.intensity, 0f, fadespeed * Time.deltaTime);
        }
    }
    void CheckTargetIntensity() {
        if (Mathf.Abs(targetIntensity - alarmLight.intensity) < changeMargin) {
            if (targetIntensity == highIntensity)
            {
                targetIntensity = lowIntensity;
            }
            else {
                targetIntensity = highIntensity;
            }

        }
    }
}
