using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tayx.Graphy;

public class AxeGrab : MonoBehaviour
{
    bool activated;

    public OVRInput.Controller controller;
    public GameObject axeGameobject;
    public GameObject axeOffset;
    public GameObject trackingSpace;
    [HideInInspector]
    public Rigidbody rb;
    [HideInInspector]
    public float speed;

    private bool showUI;
    private ThrowingAxe axe;
    private OVRCameraRig rig;
    //private FixedJoint fJoint;
    

    public void Awake() {
        axe = axeGameobject.GetComponent<ThrowingAxe>();
        axe.handGameobject = this.gameObject;
        rb = GetComponent<Rigidbody>();
        rig = FindObjectOfType<OVRCameraRig>();
        //fJoint = GetComponent<FixedJoint>();
    }

    private void Update() {
        if (activated) {
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

            //if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch)) {
            //    showUI = !showUI;
            //    if (showUI) {
            //        DebugUIBuilder.instance.Show();
            //        GraphyManager.Instance.Enable();
            //    }
            //    else {
            //        DebugUIBuilder.instance.Hide();
            //        GraphyManager.Instance.Disable();
            //    }

            //}
            ////Debug.Log(OVRInput.GetLocalControllerVelocity(controller).magnitude);

            //GraphyManager.Instance.transform.position = rig.transform.TransformPoint(0, 0, 4);
            //GraphyManager.Instance.transform.rotation = rig.transform.rotation;
        }
        
    }

    public void Activate() {
        activated = true;
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
