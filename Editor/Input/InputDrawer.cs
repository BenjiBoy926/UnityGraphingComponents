using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Input<>))]
public class InputDrawer : PropertyDrawer
{
    private const float TYPE_WIDTH = 80f;
    private const float VALUE_BUFFER = 15f;

    // OVERRIDES
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect topBar = new Rect(position.position, new Vector2(position.width, GraphingEditorUtility.standardControlHeight));
        topBar = EditorGUI.PrefixLabel(position, label);

        float valueWidth = topBar.width - TYPE_WIDTH;

        // Preserve old indent
        int oldIndent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Display the type and value of the input
        topBar = OnGUIType(topBar, property);
        OnGUIValue(topBar, valueWidth, position, property);

        // Restore old indent
        EditorGUI.indentLevel = oldIndent;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float height = GraphingEditorUtility.standardControlHeight;

        if(property.FindPropertyRelative("type").enumValueIndex == 0)
        {
            float valueHeight = EditorGUI.GetPropertyHeight(property.FindPropertyRelative("_value"));
            if(valueHeight > GraphingEditorUtility.standardControlHeight)
            {
                height += valueHeight;
            }
        }

        return height;
    }

    // HELPERS
    private Rect OnGUIType(Rect position, SerializedProperty property)
    {
        position = new Rect(position.position, new Vector2(TYPE_WIDTH, position.height));
        EditorGUI.PropertyField(position, property.FindPropertyRelative("type"), GUIContent.none);
        position.x += TYPE_WIDTH;
        return position;
    }

    private void OnGUIValue(Rect topBarPosition, float width, Rect fullPosition, SerializedProperty property)
    {
        topBarPosition.width = width;

        switch(property.FindPropertyRelative("type").enumValueIndex)
        {
            case 0:
                SerializedProperty value = property.FindPropertyRelative("_value");
                float height = EditorGUI.GetPropertyHeight(value);
                Rect valuePosition = topBarPosition;

                valuePosition.x += VALUE_BUFFER;
                valuePosition.width -= VALUE_BUFFER;

                if(height > GraphingEditorUtility.standardControlHeight)
                {
                    valuePosition.x = fullPosition.x;
                    valuePosition.y = fullPosition.y + GraphingEditorUtility.standardControlHeight;
                    valuePosition.width = fullPosition.width;
                    valuePosition.height = height;

                    EditorGUI.PropertyField(valuePosition, value, true);
                }
                else EditorGUI.PropertyField(valuePosition, value, GUIContent.none, true);

                break;
            case 1:
                EditorGUI.PropertyField(topBarPosition, property.FindPropertyRelative("variable"), GUIContent.none);
                break;
            case 2:
                EditorGUI.PropertyField(topBarPosition, property.FindPropertyRelative("function"), GUIContent.none);
                break;
        }
    }
}
