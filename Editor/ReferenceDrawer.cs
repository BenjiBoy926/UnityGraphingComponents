using UnityEngine;
using UnityEditor;

public static class ReferenceDrawer
{
    public const float TYPE_WIDTH = 130f;
    public const float GENERIC_TYPENAME_MULTIPLIER = 10f;

    public static void OnGUIType(Rect content, SerializedProperty property)
    {
        // Calculate the content for the reference button toggle and the reference drawer
        Rect rect = new Rect(content.x, content.y, TYPE_WIDTH, content.height);
        EditorGUI.PropertyField(rect, property.FindPropertyRelative("type"), GUIContent.none);
    }

    public static void OnGUIReference(Rect content, SerializedProperty property, int offset)
    {
        float typenameWidth = DisplayVariableGenericTypeName(content, property);

        Rect rect = new Rect(
            content.x + TYPE_WIDTH + EditorGUIUtility.standardVerticalSpacing,
            content.y,
            content.width - TYPE_WIDTH - typenameWidth - EditorGUIUtility.standardVerticalSpacing,
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

    private static float DisplayVariableGenericTypeName(Rect content, SerializedProperty property)
    {
        // Display a label for the type of the object picker
        string typeName = GetVariableGenericTypeName(property);
        float typeWidth = GetVariableGenericTypeWidth(typeName);
        Rect typeRect = new Rect(content.x + content.width - typeWidth, content.y, typeWidth, content.height);
        
        // Get the style for the type name
        GUIStyle typeStyle = new GUIStyle();
        typeStyle.fontStyle = FontStyle.Bold;
        typeStyle.alignment = TextAnchor.MiddleCenter;

        EditorGUI.LabelField(typeRect, "(" + typeName + ")", typeStyle);
        return typeWidth;
    }

    private static string GetVariableGenericTypeName(SerializedProperty property)
    {
        System.Reflection.FieldInfo fieldInfo = property.serializedObject.targetObject.GetType().GetField(property.propertyPath);
        if (fieldInfo != null) return fieldInfo.FieldType.GetGenericArguments()[0].Name;
        else return "X";
    }

    private static float GetVariableGenericTypeWidth(string type)
    {
        return type.Length * GENERIC_TYPENAME_MULTIPLIER;
    }
}
