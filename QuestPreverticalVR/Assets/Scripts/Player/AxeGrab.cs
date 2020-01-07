using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AxeGrab : MonoBehaviour
{
    public OVRInput.Controller controller;
    public GameObject axeGameobject;
    public GameObject axeOffset;
    public GameObject trackingSpace;
    [HideInInspector]
    public Rigidbody rb;
    [HideInInspector]
    public float speed;


    private ThrowingAxe axe;
    //private FixedJoint fJoint;
    

    public void Awake() {
        axe = axeGameobject.GetComponent<ThrowingAxe>();
        axe.handGameobject = this.gameObject;
        rb = GetComponent<Rigidbody>();
        //fJoint = GetComponent<FixedJoint>();
    }

    private void Update() {
        speed = OVRInput.GetLocalControllerVelocity(controller).magnitude;
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, controller)) {
            axe.ReturnToHand();
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, controller)) {
            DropAxe();
            //axe.StopReturnToHand();
            if (speed > 1) {
                axe.Throw();
            }
        }
        //Debug.Log(OVRInput.GetLocalControllerVelocity(controller).magnitude);
        
    }

    public void GrabbAxe() {
        axeGameobject.transform.parent = this.transform;
        axe.rb.isKinematic = true;
        //fJoint.connectedBody = axeGameobject.GetComponent<Rigidbody>();
    }

    public void DropAxe() {
        axe.rb.isKinematic = false;
        axeGameobject.transform.parent = null;

        //fJoint.connectedBody = null;
        axe.rb.useGravity = true;
    }
}
