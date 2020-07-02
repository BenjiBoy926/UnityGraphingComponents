using UnityEngine;
using UnityEditor;

public class EditorReferenceDrawer
{
    public static void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect content = EditorGUI.PrefixLabel(position, label);

        // Calculate the content for the reference button toggle and the reference drawer
        float typeWidth = 90f;
        Rect typeRect = new Rect(content.x, content.y, typeWidth, content.height);
        Rect valueRect = new Rect(
            content.x + typeWidth + EditorGUIUtility.standardVerticalSpacing,
            content.y,
            content.width - typeWidth - EditorGUIUtility.standardVerticalSpacing,
            content.height);

        // Set up the editor for the reference type
        SerializedProperty switchProperty = property.FindPropertyRelative("type");
        EditorGUI.PropertyField(typeRect, switchProperty, GUIContent.none);

        if (switchProperty.enumValueIndex == 0)
        {
            EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("value"), GUIContent.none);
        }
        else
        {
            EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("component"), GUIContent.none);
        }
    }

    public static float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
    }
}