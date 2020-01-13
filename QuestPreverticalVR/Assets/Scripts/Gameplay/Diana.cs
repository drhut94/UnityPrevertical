using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Diana : MonoBehaviour
{
    public ColorType.color color;
    public Light light;
    public ParticleSystem particles;

    public UnityEvent OnAxeThrow;
    public bool hasBennActivated;

    public void Awake() {
        hasBennActivated = false;
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
        if (!hasBennActivated) {
            if(other.CompareTag("Axe")) {
                if(other.GetComponent<ThrowingAxe>() != null) {
                    if (other.GetComponent<ThrowingAxe>().color == color) {
                        OnAxeThrow.Invoke();
                        particles.Play();
                        hasBennActivated = true;
                    }
                }
                else {
                    if (other.gameObject.transform.parent.parent.GetComponent<ThrowingAxe>().color == color) {
                        OnAxeThrow.Invoke();
                        particles.Play();
                        hasBennActivated = true;
                    }
                }
            }
        }
    }







}
