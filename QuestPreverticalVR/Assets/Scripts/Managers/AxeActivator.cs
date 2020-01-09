using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeActivator : MonoBehaviour
{
    public AxeGrab[] axes;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            foreach(AxeGrab axe in axes) {
                axe.Activate();
            }
        }
    }
}
