using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    public void ShowText() {
        mesh.enabled = true;
    }

    public void HideText() {
        mesh.enabled = false;
    }

    public void DestroyText() {
        Destroy(this.gameObject);
    }
}
