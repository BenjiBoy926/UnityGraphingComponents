using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(IntFromVector))]
public class FromVectorDrawer : PropertyDrawer
{
    private const float TYPE_WIDTH = 80f;
    private const float RADIO_BUFFER = 30f;

    // Component labels
    private static string[] vector2Components =
    {
        " X", " Y"
    };
    private static string[] vector3Components =
    {
        " X", " Y", " Z"
    };

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty type = property.FindPropertyRelative("type");
        SerializedProperty component = property.FindPropertyRelative("component");
        SerializedProperty vector;
        string[] componentNames;

        Rect rect = new Rect(
            position.position, 
            new Vector2(position.width, GraphingEditorUtility.standardControlHeight));
        Rect typeContent = EditorGUI.PrefixLabel(rect, new GUIContent("Type"));

        // Compute rects for type and component controls
        Rect typeRect = new Rect(
            typeContent.position, 
            new Vector2(TYPE_WIDTH, GraphingEditorUtility.standardControlHeight));
        Rect componentRect = new Rect(
            typeContent.x + TYPE_WIDTH + RADIO_BUFFER, 
            typeContent.y, 
            typeContent.width - TYPE_WIDTH - RADIO_BUFFER, 
            GraphingEditorUtility.standardControlHeight);

        int oldIndent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        EditorGUI.PropertyField(typeRect, type, GUIContent.none);
        
        // Check if we are editing a vector2
        if(type.enumValueIndex == 0)
        {
            // Make sure "Z" is not selected for vector2
            if(component.enumValueIndex == 2)
            {
                component.enumValueIndex = 0;
            }

            componentNames = vector2Components;
            vector = property.FindPropertyRelative("vector2");
        }
        else
        {
            componentNames = vector3Components;
            vector = property.FindPropertyRelative("vector3");
        }

        // Create radio buttons for the selection of the component
        component.enumValueIndex = GUI.SelectionGrid(componentRect, component.enumValueIndex, componentNames, componentNames.Length, EditorStyles.radioButton);

        EditorGUI.indentLevel = oldIndent;

        rect.y += GraphingEditorUtility.standardControlHeight;
        EditorGUI.PropertyField(rect, vector, true);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        int type = property.FindPropertyRelative("type").enumValueIndex;
        float height = GraphingEditorUtility.standardControlHeight;

        if (type == 0)
        {
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("vector2"));
        }
        else height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("vector3"));

        return height;
    }
}
