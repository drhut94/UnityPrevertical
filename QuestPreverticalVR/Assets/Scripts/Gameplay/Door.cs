using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public AnimationCurve curve;
    public float time;
    public int torchesToOpen;
    public Vector3 direction;

    //private int torchesActivated;
    private float timer;
    private Vector3 initPos;

    public void Start() {
        initPos = transform.position;
        timer = 0.001f;
        //StartCoroutine(OpenDoorRoutine());
    }


    public void OpenDoor() {
        Debug.Log("OpenDoor");
        torchesToOpen--;
        if(torchesToOpen <= 0) {
            StartCoroutine(OpenDoorRoutine());
        }
    }

    IEnumerator OpenDoorRoutine() {
        while((timer / time) < 1) {
            Debug.Log("OpenningDoor");
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(initPos, initPos + direction, timer / time);
            yield return null;
        }
    }
}
