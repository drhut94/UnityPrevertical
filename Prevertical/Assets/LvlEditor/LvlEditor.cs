using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LvlEditor : MonoBehaviour
{
    public List<GameObject> prefabs;
    public Vector3 lookAtPoint = Vector3.zero;
    public bool isActive;
    public bool settings;
    public bool init;

    // Update is called once per frame
    void Update()
    {
        init = false;
    }

    public void EnableEditorMode() {
        Debug.Log("<color=red>Editor mode is now enabled</color>");
        isActive = true;
        if (!init) {
            init = true;
            SpawnPrefab(prefabs[0], Vector3.zero, Quaternion.identity);
        }
    }

    public void DisableEditorMode() {
        Debug.Log("Editor mode is now disabled");
        isActive = false;
    }

    public void EnableSettings() {
        settings = true;
    }

    public void DisableSettings() {
        settings = false;
    }

    private void SpawnPrefab(GameObject prefab, Vector3 pos, Quaternion rotation) {
        Instantiate(prefab, pos, rotation);
    }
}
