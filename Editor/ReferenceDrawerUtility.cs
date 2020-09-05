using UnityEngine;
using UnityEditor;

public static class ReferenceDrawerUtility
{
    public const float TYPE_WIDTH = 130f;
    public const float GENERIC_TYPENAME_MULTIPLIER = 10f;

    public static void OnGUIType(Rect content, SerializedProperty property)
    {
        // Calculate the content for the reference button toggle and the reference drawer
        Rect rect = new Rect(content.x, content.y, TYPE_WIDTH, content.height);
        EditorGUI.PropertyField(rect, property.FindPropertyRelative("type"), GUIContent.none);
    }

    public static void OnGUIReference(Rect content, SerializedProperty property, string genericTypename, int offset)
    {  
        Rect rect = new Rect(
            content.x + TYPE_WIDTH + EditorGUIUtility.standardVerticalSpacing,
            content.y,
            content.width - TYPE_WIDTH - EditorGUIUtility.standardVerticalSpacing,
            content.height);
        int enumIndex = property.FindPropertyRelative("type").enumValueIndex;

        if(enumIndex == (0 + offset))
        {
            EditorGUI.PropertyField(rect, property.FindPropertyRelative("directReference"), GUIContent.none);
        }
        else if(enumIndex == (1 + offset))
        {
            EditorGUI.PropertyField(rect, property.FindPropertyRelative("indirectReference"), GUIContent.none);
        }
        else
        {
            EditorGUI.PropertyField(rect, property.FindPropertyRelative("tag"), GUIContent.none);
        }
    }

    // OBSOLETE
    private static float DisplayVariableGenericTypeName(Rect content, string genericTypename)
    {
        // Display a label for the type of the object picker
        float typeWidth = GetVariableGenericTypeWidth(genericTypename);
        Rect typeRect = new Rect(content.x + content.width - typeWidth, content.y, typeWidth, content.height);
        
        // Get the style for the type name
        GUIStyle typeStyle = new GUIStyle();
        typeStyle.fontStyle = FontStyle.Bold;
        typeStyle.alignment = TextAnchor.MiddleCenter;

        EditorGUI.LabelField(typeRect, genericTypename, typeStyle);
        return typeWidth;
    }
    private static float GetVariableGenericTypeWidth(string type)
    {
        return type.Length * GENERIC_TYPENAME_MULTIPLIER;
    }
}
