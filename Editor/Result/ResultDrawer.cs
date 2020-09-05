using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Result<>))]
public class ResultDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect content = EditorGUI.PrefixLabel(position, label);
        ReferenceDrawerUtility.OnGUIType(content, property);
        ReferenceDrawerUtility.OnGUIReference(content, property, fieldInfo.FieldType.GetGenericArguments()[0].Name, 0);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return GraphingEditorUtility.standardControlHeight;
    }
}
