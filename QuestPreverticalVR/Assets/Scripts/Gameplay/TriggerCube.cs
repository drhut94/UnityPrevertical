using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerCube : MonoBehaviour
{
    public UnityEvent onPlayerEnter;

    public UnityEvent onPlayerExtit;

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            onPlayerEnter.Invoke();
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            onPlayerExtit.Invoke();
        }
    }
}
