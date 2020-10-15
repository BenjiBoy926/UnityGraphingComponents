using UnityEngine;
using UnityEditor;

public static class ComplexListEditor
{
    // CONSTANTS
    private const float MINI_BUTTON_LEFT_MARGIN = 4f;
    private const float MINI_BUTTON_AREA_WIDTH = 16f;
    private const float MINI_BUTTON_WIDTH = MINI_BUTTON_LEFT_MARGIN + MINI_BUTTON_AREA_WIDTH;

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
    public static void OnGUI(Rect position, SerializedProperty property, GUIContent label, bool foldout = true)
    {
        if (property.isArray)
        {
            OnGUIList(position, property, label);
        }
        else
        {
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

    private static void OnGUIList(Rect position, SerializedProperty property, GUIContent label, bool foldout = true)
    {
        
        // Check if we want to use a foldout for the list
        if (foldout)
        {
            Rect foldoutRect = new Rect(position.position, new Vector2(position.width, GraphingEditorUtility.standardControlHeight));
            property.isExpanded = EditorGUI.Foldout(foldoutRect, property.isExpanded, label);
            EditorGUI.indentLevel++;

            position.y += GraphingEditorUtility.standardControlHeight;
            position.height -= GraphingEditorUtility.standardControlHeight;
        }
        else property.isExpanded = true;

        // If property is expanded, edit the elements
        if (property.isExpanded)
        {
            OnGUIElements(position, property);
        }

        if(foldout)
        {
            EditorGUI.indentLevel--;
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
            position.width -= MINI_BUTTON_WIDTH * 3f;

            for (int i = 0; i < property.arraySize; i++)
            {
                // Edit the current list element
                position.height = EditorGUI.GetPropertyHeight(property.GetArrayElementAtIndex(i), true);
                EditorGUI.PropertyField(position, property.GetArrayElementAtIndex(i), true);

                // Edit the buttons for the current list element
                buttonPositions = new Rect(position.x + position.width, position.y, MINI_BUTTON_WIDTH * 3f, GraphingEditorUtility.standardControlHeight);
                OnGUIButtons(buttonPositions, property, i);

                // Move position down
                position.y += position.height;
            }
        }
    }

    private static void OnGUIButtons(Rect position, SerializedProperty property, int index)
    {
        // Move down button moves the array element down int he list
        position.width = MINI_BUTTON_AREA_WIDTH;
        position.x += MINI_BUTTON_LEFT_MARGIN;
        if (GUI.Button(position, "\u21b4", buttonStyle))
        {
            property.MoveArrayElement(index, index + 1);
        }
        position.x += position.width + MINI_BUTTON_LEFT_MARGIN;

        // Insert button inserts an array element after this element
        if (GUI.Button(position, "+", buttonStyle))
        {
            property.InsertArrayElementAtIndex(index);
        }
        position.x += position.width + MINI_BUTTON_LEFT_MARGIN;

        // Delete button deletes the element in the list
        if (GUI.Button(position, "-", buttonStyle))
        {
            property.DestroyArrayElement(index);
        }
    }
}