using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Result<>))]
public class ResultDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect content = EditorGUI.PrefixLabel(position, label);
        ReferenceDrawer.OnGUIType(content, property);
        ReferenceDrawer.OnGUIReference(content, property, 0);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return GraphingEditorUtility.standardControlHeight;
    }
}
