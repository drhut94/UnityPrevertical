using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject[] playerObjects;

    public void Start() {
        SpawnPlayer();
    }

    public void SpawnPlayer() {
        foreach(GameObject obj in playerObjects) {
            Instantiate(obj, transform.position, transform.rotation);
        }
    }
}
