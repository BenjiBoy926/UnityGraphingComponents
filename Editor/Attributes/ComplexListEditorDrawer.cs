using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ComplexListEditorAttribute))]
public class ComplexListEditorDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ComplexListEditor.OnGUI(position, property, label);
    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return ComplexListEditor.GetPropertyHeight(property, label);
    }
}