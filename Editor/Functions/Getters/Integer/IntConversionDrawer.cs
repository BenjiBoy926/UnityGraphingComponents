using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(IntConversion))]
public class IntConversionDrawer : PropertyDrawer
{
    private static string[] propertyNames =
    {
        "boolInput", "fromFloat", "stringInput", "fromVector"
    };

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty conversion = property.FindPropertyRelative("conversion");

        Rect rect = new Rect(position.position, new Vector2(position.width, GraphingEditorUtility.standardControlHeight));
        EditorGUI.PropertyField(rect, conversion);

        rect.y += GraphingEditorUtility.standardControlHeight;
        EditorGUI.PropertyField(rect, property.FindPropertyRelative(propertyNames[conversion.enumValueIndex]), true);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        int conversion = property.FindPropertyRelative("conversion").enumValueIndex;
        float height = GraphingEditorUtility.standardControlHeight;

        height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative(propertyNames[conversion]));

        return height;
    }
}
