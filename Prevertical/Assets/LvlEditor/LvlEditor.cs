using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LvlEditor : MonoBehaviour
{
    public Vector3 lookAtPoint = Vector3.zero;
    public bool isActive;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(lookAtPoint);
    }

    public void EnableEditorMode() {
        Debug.Log("<color=red>Editor mode is now enabled</color>");
        isActive = true;
    }

    public void DisableEditorMode() {
        Debug.Log("Editor mode is now disabled");
        isActive = false;
    }
}
