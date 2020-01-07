using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsHand : MonoBehaviour
{
    Rigidbody rb;
    public Transform targetHandTrans;
    public Vector3 rotationOfsett;


    public void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate() {
        
        Vector3 mov = Vector3.MoveTowards(transform.position, targetHandTrans.position, (transform.position - targetHandTrans.position).magnitude / Time.deltaTime * 0.8f);
        rb.velocity = (mov - transform.position) / Time.deltaTime* 0.9f;

        rb.rotation = targetHandTrans.rotation;
    }


}
