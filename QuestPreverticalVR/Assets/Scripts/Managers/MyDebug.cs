using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyDebug : MonoBehaviour
{
    [HideInInspector]
    public static MyDebug instance;

    public TextMeshPro text;

    #region Singleton
    public void Awake() {
        DontDestroyOnLoad(this);
        if(instance = null) {
            instance = this;
        }
    }
    #endregion

    public void Log(string obj) {
        text.text = obj;
    }
}
