using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLerp : MonoBehaviour
{
    public Transform targetHand;
    Rigidbody rb;
    ConfigurableJoint springJoint;

    public void Awake() {
        rb = GetComponent<Rigidbody>();
        springJoint = GetComponent<ConfigurableJoint>();
    }

    public void Start() {
        transform.position = targetHand.transform.position;
        transform.rotation = targetHand.transform.rotation;
        StartCoroutine(ActivateCollider());
    }

    public void Update() {
        springJoint.connectedAnchor = targetHand.position;
        transform.rotation = targetHand.rotation;
    }

    IEnumerator ActivateCollider() {
        yield return new WaitForSeconds(1);
        transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
    }

    private void OnCollisionEnter(Collision collision) {
        //springJoint.xDrive.positionSpring = 10;
    }
}
