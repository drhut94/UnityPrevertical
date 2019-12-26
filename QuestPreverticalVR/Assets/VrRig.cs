using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class VrMap {
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffsett;
    public Vector3 trackingRotationOffsett;

    public void Map() {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffsett);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffsett);
    }
}


public class VrRig : MonoBehaviour
{
    public VrMap head;
    public VrMap leftHand;
    public VrMap rightHand;


    public Transform headConstraint;
    public Vector3 headBodyOffset;

    public void Start() {
        headBodyOffset = transform.position - headConstraint.position;
    }

    public void Update() {
        transform.position = headConstraint.position + headBodyOffset;
        transform.forward = Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized;

        head.Map();
        leftHand.Map();
        rightHand.Map();

    }

}

