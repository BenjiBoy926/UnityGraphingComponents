using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(OutputList))]
public class OutputListDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ComplexListEditor.OnGUI(position, property.FindPropertyRelative("outputs"), label);
        //EditorGUI.PropertyField(position, property.FindPropertyRelative("outputs"), label, true);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return ComplexListEditor.GetPropertyHeight(property.FindPropertyRelative("outputs"), label);
        //return EditorGUI.GetPropertyHeight(property.FindPropertyRelative("outputs"), true);
    }
}