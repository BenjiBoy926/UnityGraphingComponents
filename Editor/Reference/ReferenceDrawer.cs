using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public static class ReferenceDrawer
{
    public const float TYPE_WIDTH = 80f;
   
    public static void OnGUI(Rect position, SerializedProperty property, GUIContent label, 
        ReferenceDrawerType drawerType, ReferenceDataType dataType, ref bool mainFoldout, ref bool advancedFoldout)
    {
        // Get some important enum values, and starting rect
        SerializedProperty referenceType = property.FindPropertyRelative("referenceType");
        SerializedProperty gameObjectReferenceType = property.FindPropertyRelative("gameObjectReferenceType");
        Rect rect = new Rect(position.position, new Vector2(position.width, GraphingEditorUtility.standardControlHeight));

        // Put the foldout item
        mainFoldout = EditorGUI.Foldout(rect, mainFoldout, label);
        rect.y += GraphingEditorUtility.standardControlHeight;

        if (mainFoldout)
        {
            // Put the reference type
            EditorGUI.indentLevel++;
            rect = OnGUIType(rect, property, drawerType);

            switch(referenceType.enumValueIndex)
            {
                // GUI for a direct value
                case 0:
                    SerializedProperty direct = property.FindPropertyRelative("direct");
                    EditorGUI.PropertyField(rect, direct);
                    rect.y += EditorGUI.GetPropertyHeight(direct);
                    break;
                // GUI for the indirect value
                case 1:
                    EditorGUI.PropertyField(rect, property.FindPropertyRelative("indirect"));
                    rect.y += GraphingEditorUtility.standardControlHeight;
                    break;
                // GUI for a redirected value
                case 2:
                    // Display game object reference
                    EditorGUI.PropertyField(rect, gameObjectReferenceType);
                    rect.y += GraphingEditorUtility.standardControlHeight;

                    // Display drawer for game object variable or tag
                    if (gameObjectReferenceType.enumValueIndex == 0)
                    {
                        EditorGUI.PropertyField(rect, property.FindPropertyRelative("redirectVariable"));
                    }
                    else EditorGUI.PropertyField(rect, property.FindPropertyRelative("redirectTag"));
                    rect.y += GraphingEditorUtility.standardControlHeight;

                    // Display advanced options
                    rect = OnGUIAdvancedOptions(rect, property, drawerType, dataType, ref advancedFoldout);

                    break;
            }

            EditorGUI.indentLevel--;
        }
    }

    public static float GetPropertyHeight(SerializedProperty property, GUIContent content,  
        ReferenceDrawerType drawerType, ReferenceDataType dataType, bool mainFoldout, bool advancedFoldout)
    {
        // Account for the foldout line
        float current = GraphingEditorUtility.standardControlHeight;

        if (mainFoldout)
        {
            SerializedProperty referenceType = property.FindPropertyRelative("referenceType");

            // Account for reference type height
            current += GraphingEditorUtility.standardControlHeight;

            // Account for value height
            if (referenceType.enumValueIndex == 0)
            {
                current += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("direct"));
            }
            else current += GraphingEditorUtility.standardControlHeight;

            // If reference is a redirect, account for game object redirect type and advanced foldout
            if(referenceType.enumValueIndex == 2)
            {
                current += 2f * GraphingEditorUtility.standardControlHeight;

                // If advanced options are opened up, account for redirect depth
                if(advancedFoldout)
                {
                    current += GraphingEditorUtility.standardControlHeight;

                    // If reference drawer is for input and a GameObject or Component,
                    // account for redirect type height
                    if(drawerType == ReferenceDrawerType.Input && dataType == ReferenceDataType.GameObjectOrComponent)
                    {
                        current += GraphingEditorUtility.standardControlHeight;
                    }
                }
            }
        }

        return current;
    }

    private static Rect OnGUIType(Rect content, SerializedProperty property, ReferenceDrawerType drawerType)
    {
        // Calculate the content for the reference button toggle and the reference drawer
        SerializedProperty referenceType = property.FindPropertyRelative("referenceType");

        // If not an input type, display property as normal
        if (drawerType == ReferenceDrawerType.Input)
        {
            EditorGUI.PropertyField(content, referenceType);
        }
        // If this is a result, remove the first enum option
        else
        {
            int newValue = referenceType.enumValueIndex - 1;
            if (newValue < 0)
            {
                newValue = 0;
            }

            List<string> enumOptions = new List<string>(referenceType.enumDisplayNames);

            // Put in a popup with the first enum option removed
            enumOptions.RemoveAt(0);
            newValue = EditorGUI.Popup(content, "Reference Type", newValue, enumOptions.ToArray());

            referenceType.enumValueIndex = newValue + 1;
        }

        return new Rect(content.x, content.y + GraphingEditorUtility.standardControlHeight, 
            content.width, content.height);
    }

    public static Rect OnGUIAdvancedOptions(Rect current, SerializedProperty property, 
        ReferenceDrawerType drawerType, ReferenceDataType dataType, ref bool advancedFoldout)
    {
        advancedFoldout = EditorGUI.Foldout(current, advancedFoldout, new GUIContent("Advanced"));
        current.y += GraphingEditorUtility.standardControlHeight;

        if(advancedFoldout)
        {
            EditorGUI.indentLevel++;

            // If drawer is input, display redirect type
            if(drawerType == ReferenceDrawerType.Input && dataType == ReferenceDataType.GameObjectOrComponent)
            {
                EditorGUI.PropertyField(current, property.FindPropertyRelative("redirectType"));
                current.y += GraphingEditorUtility.standardControlHeight;
            }

            // Display redirect depth
            EditorGUI.PropertyField(current, property.FindPropertyRelative("redirectDepth"));
            current.y += GraphingEditorUtility.standardControlHeight;

            EditorGUI.indentLevel--;
        }

        return current;
    }

    public static void OnGUIType(Rect content, SerializedProperty property, bool typeofComponent)
    {
        // Calculate the content for the reference button toggle and the reference drawer
        Rect rect = new Rect(content.x, content.y, TYPE_WIDTH, content.height);
        SerializedProperty type = property.FindPropertyRelative("type");

        // If not a reference type, display property as normal
        if(!typeofComponent)
        {
            EditorGUI.PropertyField(rect, type, GUIContent.none);
        }
        // If this is a reference, remove the first enum option
        else
        {
            int newValue = type.enumValueIndex - 1;
            if(newValue < 0)
            {
                newValue = 0;
            }

            List<string> enumOptions = new List<string>(type.enumDisplayNames);

            // Put in a popup with the first enum option removed
            enumOptions.RemoveAt(0);
            newValue = EditorGUI.Popup(rect, newValue, enumOptions.ToArray());

            type.enumValueIndex = newValue + 1;
        }
    }

    public static void OnGUIReference(Rect content, SerializedProperty property, bool typeofComponent)
    {  
        Rect rect = new Rect(
            content.x + TYPE_WIDTH + EditorGUIUtility.standardVerticalSpacing,
            content.y,
            content.width - TYPE_WIDTH - EditorGUIUtility.standardVerticalSpacing,
            content.height);
        string directReferenceProperty = typeofComponent ? "directValue" : "directReference";

        switch(property.FindPropertyRelative("type").enumValueIndex)
        {
            case 1:
                EditorGUI.PropertyField(rect, property.FindPropertyRelative(directReferenceProperty), GUIContent.none);
                break;
            case 2:
                EditorGUI.PropertyField(rect, property.FindPropertyRelative("indirectReference"), GUIContent.none);
                break;
            case 3:
                EditorGUI.PropertyField(rect, property.FindPropertyRelative("tag"), GUIContent.none);
                break;
        }
    }
}
