using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomEditorWindow : EditorWindow
{

    [MenuItem("Window/My Window")]

    static void Init() {
        // Get existing open window or if none, make a new one:
        CustomEditorWindow window = (CustomEditorWindow)EditorWindow.GetWindow(typeof(CustomEditorWindow));
        window.Show();
    }

    private void OnSelectionChange() {
        Debug.Log("looool");
    }
}
