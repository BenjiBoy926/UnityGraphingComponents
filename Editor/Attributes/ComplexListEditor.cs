using UnityEngine;
using UnityEditor;

public static class ComplexListEditor
{
    // CONSTANTS
    private const float MINI_BUTTON_WIDTH = 30f;
    private const float MINI_BUTTON_BUFFER = 10f;

    // FIELDS
    private static GUIStyle buttonStyle = new GUIStyle()
    {
        alignment = TextAnchor.MiddleCenter,
        fontStyle = FontStyle.Bold,

        // mouse state
        normal = new GUIStyleState()
        {
            background = Texture2D.whiteTexture
        },
        hover = new GUIStyleState()
        {
            background = Texture2D.grayTexture
        },
        active = new GUIStyleState()
        {
            background = Texture2D.blackTexture
        }
    };

    // METHODS
    public static void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.isArray)
        {
            OnGUIList(position, property, label);
        }
        else
        {
            Debug.LogWarning(property.propertyPath + " is not an array.");
            EditorGUI.PropertyField(position, property, true);
        }
    }
    public static float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (property.isArray)
        {
            return GetPropertyArrayHeight(property);
        }
        else
        {
            return EditorGUI.GetPropertyHeight(property, true);
        }
    }

    // HELPERS
    // Get the height of the property, assuming it is an array
    private static float GetPropertyArrayHeight(SerializedProperty property)
    {
        float height = GraphingEditorUtility.standardControlHeight;

        if (property.isExpanded)
        {
            // If array is emtpy, add space for add button
            if(property.arraySize <= 0)
            {
                height *= 2f;
            }
            // If array is not empty, add up all element heights
            else
            {
                for (int i = 0; i < property.arraySize; i++)
                {
                    height += EditorGUI.GetPropertyHeight(property.GetArrayElementAtIndex(i), true);
                }
            }
        }

        return height;
    }

    private static void OnGUIList(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect foldoutRect = new Rect(position.position, new Vector2(position.width, GraphingEditorUtility.standardControlHeight));
        property.isExpanded = EditorGUI.Foldout(foldoutRect, property.isExpanded, label);

        position.y += GraphingEditorUtility.standardControlHeight;
        position.height -= GraphingEditorUtility.standardControlHeight;

        // If property is expanded, edit the elements
        if (property.isExpanded)
        {
            OnGUIElements(position, property);
        }
    }

    private static void OnGUIElements(Rect position, SerializedProperty property)
    {
        GUI.backgroundColor = Color.white;

        if (property.arraySize <= 0)
        {
            // Display one large add button
            if (GUI.Button(position, "+", buttonStyle))
            {
                property.InsertArrayElementAtIndex(0);
            }
        }
        else
        {
            Rect buttonPositions;
            position.width -= (MINI_BUTTON_WIDTH * 3f + MINI_BUTTON_BUFFER);

            for (int i = 0; i < property.arraySize; i++)
            {
                // Edit the current list element
                position.height = EditorGUI.GetPropertyHeight(property.GetArrayElementAtIndex(i), true);
                EditorGUI.PropertyField(position, property.GetArrayElementAtIndex(i), true);

                // Edit the buttons for the current list element
                buttonPositions = new Rect(position.x + position.width + MINI_BUTTON_BUFFER, position.y, MINI_BUTTON_WIDTH * 3f, GraphingEditorUtility.standardControlHeight);
                OnGUIButtons(buttonPositions, property, i);

                // Move position down
                position.y += position.height;
            }
        }
    }

    private static void OnGUIButtons(Rect position, SerializedProperty property, int index)
    {
        // Move down button moves the array element down int he list
        position.width = MINI_BUTTON_WIDTH;
        if (GUI.Button(position, "\u21b4", buttonStyle))
        {
            property.MoveArrayElement(index, index + 1);
        }
        position.x += MINI_BUTTON_WIDTH;

        // Insert button inserts an array element after this element
        if (GUI.Button(position, "+", buttonStyle))
        {
            property.InsertArrayElementAtIndex(index);
        }
        position.x += MINI_BUTTON_WIDTH;

        // Delete button deletes the element in the list
        if (GUI.Button(position, "-", buttonStyle))
        {
            // Ensure that the property is properly deleted
            int oldSize = property.arraySize;
            property.DeleteArrayElementAtIndex(index);
            if (property.arraySize == oldSize)
            {
                property.DeleteArrayElementAtIndex(index);
            }
        }
    }
}