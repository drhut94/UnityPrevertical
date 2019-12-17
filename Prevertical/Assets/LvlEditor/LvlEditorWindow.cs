using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LvlEditor))]
[CanEditMultipleObjects]
public class LvlEditorWindow : Editor
{
    //SerializedProperty lookAtPoint;
    SerializedProperty prefabs;

    // Start is called before the first frame update
    void OnEnable() {
        //lookAtPoint = serializedObject.FindProperty("lookAtPoint");
        prefabs = serializedObject.FindProperty("prefabs");
        EditorWindow.
    }

   
    public override void OnInspectorGUI() {

        LvlEditor lvlEditor = (LvlEditor)target;

        EditorGUILayout.Space(20);
        GUI.backgroundColor = lvlEditor.isActive ? Color.red : Color.green;


        if (GUILayout.Button(lvlEditor.isActive ? "DISABLE EDITOR MODE" : "ENABLE EDITOR MODE", GUILayout.Height(80))) {
            if (lvlEditor.isActive)
                lvlEditor.DisableEditorMode();
            else
                lvlEditor.EnableEditorMode();
        }

        EditorGUILayout.Space(20);

        if (lvlEditor.isActive) {
            GUI.backgroundColor = Color.white;

            foreach (GameObject prefab in lvlEditor.prefabs) {

                GUILayout.BeginHorizontal("box");

                if (GUILayout.Button(prefab.name, GUILayout.Height(110), GUILayout.Width(110))) {
                    
                }

                GUILayout.EndHorizontal();
            }

            GUI.backgroundColor = Color.white;
            EditorGUILayout.Space(20);
        }

        GUI.backgroundColor = Color.cyan;

        if (GUILayout.Button("SETTINGS", GUILayout.Height(50))) {
            if (lvlEditor.settings)
                lvlEditor.DisableSettings();
            else
                lvlEditor.EnableSettings();
            
        }

        GUI.backgroundColor = Color.white;

        if (lvlEditor.settings) {


            EditorGUILayout.PropertyField(prefabs);        
        }
        

        serializedObject.Update();
        //EditorGUILayout.PropertyField(lookAtPoint);
        serializedObject.ApplyModifiedProperties();
    }

    private void OnSceneGUI() {
        if (Event.current.type == EventType.Layout) {
            HandleUtility.AddDefaultControl(0);
        }
    }
}
