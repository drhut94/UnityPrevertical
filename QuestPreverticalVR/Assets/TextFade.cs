using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextFade : MonoBehaviour
{
    Text text;

    public void Start() {
        text = GetComponent<Text>();
    }

    public void FixedUpdate() {
        text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Abs(Mathf.Sin(Time.time)));
    }

    public void Update() {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch)) {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch)) {
                SceneManager.LoadScene(1);
            }
        }
    }
}
