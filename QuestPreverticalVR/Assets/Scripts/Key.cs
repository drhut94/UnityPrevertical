using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    public UnityEvent onKeyGrabb;


    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            if (Input.GetKeyDown(KeyCode.E)) {
                onKeyGrabb.Invoke();
                Destroy(this.gameObject);
            }
        }
    }
}
