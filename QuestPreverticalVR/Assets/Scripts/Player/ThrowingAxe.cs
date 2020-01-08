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

    public GameObject tRenderer;
    public ColorType.color color;

    private AxeGrab hand;
    private float throwSpeed;
    private GameObject childModel;

    public void Awake() {
        rb = GetComponent<Rigidbody>();
        isThrowing = true;
        childModel = transform.GetChild(0).gameObject;
        tRenderer.SetActive(false);
    }

    public void Start() {
        hand = handGameobject.GetComponent<AxeGrab>();
    }

    public void ReturnToHand() {
        rb.useGravity = false;
        StartCoroutine(AxeReturnToHand());
        isThrowing = false;
        tRenderer.SetActive(false);
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
        tRenderer.SetActive(true);
        StartCoroutine(ThrowAxe());
    }

    IEnumerator ThrowAxe() {
        while (isThrowing) {
            rb.velocity = -transform.right * throwSpeed * 1.2f;
            childModel.transform.Rotate(0,throwSpeed * 7,0);
            transform.rotation = hand.axeOffset.transform.rotation;
            yield return null;
        }
    }

    private IEnumerator AxeReturnToHand() {
        while(Vector3.Distance(transform.position, hand.axeOffset.transform.position) > 0.1f) {
            rb.transform.position = Vector3.MoveTowards(transform.position, handGameobject.transform.position, 0.2f);
            yield return null;
        }
        transform.position = hand.axeOffset.transform.position;
        transform.rotation = hand.axeOffset.transform.rotation;
        hand.GrabbAxe();
        childModel.transform.rotation = hand.axeOffset.transform.rotation;
    }

    private void OnTriggerEnter(Collider other) {
        rb.isKinematic = true;
        isThrowing = false;

        //CubeCut.Cut(other.transform, transform.position);
    }


}
