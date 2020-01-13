using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnPlayer : MonoBehaviour
{
    public GameObject player;


    public void RespawnPlayers() {
        SceneManager.LoadScene(3);
    }
}
