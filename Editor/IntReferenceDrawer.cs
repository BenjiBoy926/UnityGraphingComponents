﻿using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(IntReference))]
public class IntReferenceDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorReferenceDrawer.OnGUI(position, property, label);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorReferenceDrawer.GetPropertyHeight(property, label);
    }
}