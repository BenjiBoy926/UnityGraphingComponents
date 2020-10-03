using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Result<>))]
public class ResultDrawer : PropertyDrawer
{
    private const float TYPE_WIDTH = 80f;

    // OVERRIDES
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        position = EditorGUI.PrefixLabel(position, label);

        int oldIndent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        float valueWidth = position.width - TYPE_WIDTH;

        // Display GUI for type select
        position.width = TYPE_WIDTH;
        OnGUIType(position, property);

        // Display GUI for value select
        position.x += TYPE_WIDTH;
        position.width = valueWidth;
        OnGUIValue(position, property);

        EditorGUI.indentLevel = oldIndent;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return GraphingEditorUtility.standardControlHeight;
    }

    // HELPERS
    private void OnGUIType(Rect position, SerializedProperty property)
    {
        EditorGUI.PropertyField(position, property.FindPropertyRelative("type"), GUIContent.none);
    }

    private void OnGUIValue(Rect position, SerializedProperty property)
    {
        switch(property.FindPropertyRelative("type").enumValueIndex)
        {
            case 0:
                EditorGUI.PropertyField(position, property.FindPropertyRelative("variable"), GUIContent.none);
                break;
            case 1:
                EditorGUI.PropertyField(position, property.FindPropertyRelative("function"), GUIContent.none);
                break;
        }
    }
}
