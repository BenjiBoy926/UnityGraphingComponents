using UnityEngine;
using UnityEditor;

public class EditorReferenceDrawer
{
    private const float TYPE_WIDTH = 90f;
    private const float VALUE_BUFFER = 12f;

    public static void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect prefixPosition = new Rect(position.position, new Vector2(position.width, GraphingEditorUtility.standardControlHeight));
        Rect content = EditorGUI.PrefixLabel(prefixPosition, label);

        // Calculate the content for the reference button toggle and the reference drawer
        Rect rect = new Rect(content.x, content.y, TYPE_WIDTH, content.height);

        // Set up the editor for the reference type
        SerializedProperty switchProperty = property.FindPropertyRelative("type");
        EditorGUI.PropertyField(rect, switchProperty, GUIContent.none);

        if (switchProperty.enumValueIndex == 0)
        {
            OnGUIValue(position, content, property);
        }
        else
        {
            rect = new Rect(
                content.x + TYPE_WIDTH + EditorGUIUtility.standardVerticalSpacing,
                content.y,
                content.width - TYPE_WIDTH - EditorGUIUtility.standardVerticalSpacing,
                content.height);
            EditorGUI.PropertyField(rect, property.FindPropertyRelative("component"), GUIContent.none);
        }
    }

    public static float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        SerializedProperty value = property.FindPropertyRelative("value");
        SerializedProperty type = property.FindPropertyRelative("type");
        float valueHeight = EditorGUI.GetPropertyHeight(value, true);

        if (type.enumValueIndex == 1 || valueHeight <= GraphingEditorUtility.standardControlHeight)
        {
            return GraphingEditorUtility.standardControlHeight;
        }
        else return GraphingEditorUtility.standardControlHeight + valueHeight;
    }

    private static void OnGUIValue(Rect position, Rect content, SerializedProperty property)
    {
        SerializedProperty value = property.FindPropertyRelative("value");
        float height = EditorGUI.GetPropertyHeight(value, true);

        if(height <= GraphingEditorUtility.standardControlHeight)
        {
            Rect rect = new Rect(content.x + TYPE_WIDTH + VALUE_BUFFER, content.y, content.width - TYPE_WIDTH - VALUE_BUFFER, height);
            EditorGUI.PropertyField(rect, value, GUIContent.none, true);
        }
        else
        {
            Rect rect = new Rect(position.x, position.y + GraphingEditorUtility.standardControlHeight, position.width, height);
            EditorGUI.PropertyField(rect, value, true);
        }
    }
}