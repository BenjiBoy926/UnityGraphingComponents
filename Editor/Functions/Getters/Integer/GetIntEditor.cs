using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GetInt))]
[CanEditMultipleObjects]
public class GetIntEditor : Editor
{
    private static string[] propertyNames =
    {
        "operation", "conversion", "function"
    };

    public override void OnInspectorGUI()
    {
        SerializedProperty type = serializedObject.FindProperty("type");

        serializedObject.Update();

        EditorGUILayout.PropertyField(type);
        EditorGUILayout.PropertyField(serializedObject.FindProperty(propertyNames[type.enumValueIndex]));

        serializedObject.ApplyModifiedProperties();
    }
}
