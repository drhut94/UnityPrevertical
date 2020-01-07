using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingAxe : MonoBehaviour
{
    [HideInInspector]
    public GameObject handGameobject;
    [HideInInspector]
    public Rigidbody rb;
    [HideInInspector]
    public bool isThrowing;

    private AxeGrab hand;
    private float throwSpeed;
    private GameObject childModel;

    public void Awake() {
        rb = GetComponent<Rigidbody>();
        isThrowing = true;
        childModel = transform.GetChild(0).gameObject;
    }

    public void Start() {
        hand = handGameobject.GetComponent<AxeGrab>();
    }

    public void ReturnToHand() {
        rb.useGravity = false;
        StartCoroutine(AxeReturnToHand());
        isThrowing = false;
        
    }

    public void StopReturnToHand() {
        StopCoroutine(AxeReturnToHand());
        rb.useGravity = true;
        //isThrowing = false;
    }

    public void Throw() {
        rb.useGravity = false;
        Debug.Log("Throwwww");
        //rb.AddForce(transform.right * -hand.speed, ForceMode.Impulse); 
        isThrowing = true;
        throwSpeed = hand.speed;
        StartCoroutine(ThrowAxe());
    }

    IEnumerator ThrowAxe() {
        while (isThrowing) {
            rb.velocity = -transform.right * throwSpeed;
            childModel.transform.Rotate(0,throwSpeed * 4,0);
            yield return null;
        }
    }

    private IEnumerator AxeReturnToHand() {
        while(Vector3.Distance(transform.position, hand.axeOffset.transform.position) > 0.1f) {
            rb.transform.position = Vector3.MoveTowards(transform.position, handGameobject.transform.position, 0.1f);
            yield return null;
        }
        transform.position = hand.axeOffset.transform.position;
        transform.rotation = hand.axeOffset.transform.rotation;
        hand.GrabbAxe();
        childModel.transform.rotation = hand.axeOffset.transform.rotation;
    }
}
