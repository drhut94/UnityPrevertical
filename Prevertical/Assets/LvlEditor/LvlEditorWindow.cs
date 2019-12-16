using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LvlEditor))]
[CanEditMultipleObjects]
public class LvlEditorWindow : Editor
{
    //SerializedProperty lookAtPoint;

    // Start is called before the first frame update
    void OnEnable() {
        //lookAtPoint = serializedObject.FindProperty("lookAtPoint");
    }

   
    public override void OnInspectorGUI() {

        LvlEditor lvlEditor = (LvlEditor)target;

        EditorGUILayout.Space(20);
        GUI.backgroundColor = lvlEditor.isActive ? Color.red : Color.green;


        if (GUILayout.Button(lvlEditor.isActive ? "DISABLE EDITOR MODE" : "ENABLE EDITOR MODE")) {
            if (lvlEditor.isActive)
                lvlEditor.DisableEditorMode();
            else
                lvlEditor.EnableEditorMode();
        }

        GUI.backgroundColor = Color.white;
        EditorGUILayout.Space(20);

        serializedObject.Update();
        //EditorGUILayout.PropertyField(lookAtPoint);
        serializedObject.ApplyModifiedProperties();
    }


}
