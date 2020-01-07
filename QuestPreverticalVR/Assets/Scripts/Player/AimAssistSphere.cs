using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAssistSphere : MonoBehaviour
{
    public float force;
    Rigidbody[] rb;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("triggerenter");

            Vector3 dir = this.transform.position - other.transform.position;
            dir.Normalize();
            other.GetComponent<Rigidbody>().AddForce(dir * force);
            Debug.Log("autoaiming...");


    }
}
