using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Diana : MonoBehaviour
{
    public ColorType.color color;
    public Light light;

    public UnityEvent OnAxeThrow;

    public void Awake() {
        //if(color == ColorType.color.ORANGE) {
        //    GetComponent<MeshRenderer>().material.color = new Color(255, 97, 29, 255);
        //    light.color = new Color(255, 97, 29, 255);
        //}
        //else {
        //    GetComponent<MeshRenderer>().material.color = new Color(29, 206, 255);
        //    light.color = new Color(29, 206, 255);
        //}
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<ThrowingAxe>() != null) {
            if(other.GetComponent<ThrowingAxe>().color == color) {
                OnAxeThrow.Invoke();
            }
        }
    }
}
