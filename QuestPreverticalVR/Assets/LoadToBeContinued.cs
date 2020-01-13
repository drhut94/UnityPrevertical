using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadToBeContinued : MonoBehaviour
{
    public void ChangeScene() {
        SceneManager.LoadScene(2);
    }
}
