using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrab : MonoBehaviour
{

    public Transform grabPosition;
    public Transform grabDirection;
    public float throwForce;
    [SerializeField]
    public OVRInput.Controller controller;

    RaycastHit hit;
    FixedJoint fJoint;

    
    public void Awake() {
        fJoint = GetComponent<FixedJoint>();
    }

    private void Update() {
        if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch)) {
            if(Physics.SphereCast(grabPosition.position, 0.8f, grabDirection.transform.forward, out hit, 10, LayerMask.GetMask("Grabbable"))) {
                Debug.Log(hit.collider.gameObject.name);
                hit.collider.gameObject.transform.position = grabPosition.position;
                fJoint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody>();
                hit.collider.gameObject.layer = LayerMask.GetMask("Hands");
                MyDebug.instance.Log(hit.collider.gameObject.layer.ToString());
            }
        }

        if(OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch)) {
            if(fJoint.connectedBody != null) {
                fJoint.connectedBody = null;
                hit.collider.gameObject.layer = LayerMask.GetMask("Grabbable");
            }
        }

        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch)) {
            if(fJoint.connectedBody != null) {
                Rigidbody grabbedObjectRb = fJoint.connectedBody;
                fJoint.connectedBody = null;
                grabbedObjectRb.AddForce(grabPosition.right.normalized * throwForce, ForceMode.Impulse);
            }
        }
    }


}
