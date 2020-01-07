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
        //springJoint.connectedAnchor = targetHand.position;
        //transform.rotation = targetHand.rotation;
    }

    public void FixedUpdate() {
        Vector3 mov = Vector3.MoveTowards(targetHand.position, transform.position, (targetHand.position - transform.position).magnitude / Time.deltaTime * 0.8f);
        rb.velocity = (mov - targetHand.position) / Time.deltaTime * 0.9f;
    }

    IEnumerator ActivateCollider() {
        yield return new WaitForSeconds(1);
        transform.GetChild(0).GetComponent<CapsuleCollider>().enabled = true;
    }

    private void OnCollisionEnter(Collision collision) {
        //springJoint.xDrive.positionSpring = 10;
    }
}
