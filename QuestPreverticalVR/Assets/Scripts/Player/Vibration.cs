using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibration : MonoBehaviour {

    public static Vibration instance;

    #region Singleton
    private void Awake() {
        if (instance && instance != this)
            Destroy(this);
        else
            instance = this;
    }
    #endregion

    float rightTimer;
    float leftTimer;
    int iteration;
    int frequency;
    int rightStrength;
    int leftStrength;


    public void Start() {
        iteration = 40;
        frequency = 160;
    }

    public void Vibrate(float time, int strength, OVRInput.Controller controller) {

        if (controller.Equals(OVRInput.Controller.RTouch)) {
            rightTimer = time;
            rightStrength = strength;
        }
        else {
            leftTimer = time;
            leftStrength = strength;
        }
    }

    public void Update() {
        if(rightTimer > 0) {
            rightTimer -= Time.deltaTime;
            TriggerVibration(iteration, frequency, rightStrength, OVRInput.Controller.RTouch);
        }

        if(leftTimer > 0) {
            leftTimer -= Time.deltaTime;
            TriggerVibration(iteration, frequency, leftStrength, OVRInput.Controller.LTouch);
        }
    }


    public void TriggerVibration(int iteration, int frquency, int strength, OVRInput.Controller controller) {
        OVRHapticsClip clip = new OVRHapticsClip();

        for (int i = 0; i < iteration; i++) {
            clip.WriteSample(i % frquency == 0 ? (byte)strength : (byte)0);
        }

        if (controller == OVRInput.Controller.LTouch) {
            OVRHaptics.LeftChannel.Preempt(clip);
        }
        else if (controller == OVRInput.Controller.RTouch) {
            OVRHaptics.RightChannel.Preempt(clip);
        }
    }
}