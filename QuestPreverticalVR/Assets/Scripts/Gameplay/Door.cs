using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public AnimationCurve curve;
    public float time;

    public void OpenDoor() {
        transform.position += new Vector3(0,3,0);
        
    }

    //IEnumerator OpenDoorRoutine() {
       
        
    //}
}
