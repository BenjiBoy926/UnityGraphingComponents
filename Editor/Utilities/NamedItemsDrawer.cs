using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(NamedItems<>))]
[CustomPropertyDrawer(typeof(OutputPackage))]
public class NamedItemsDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Get subproperties
        SerializedProperty items = property.FindPropertyRelative("items");
        SerializedProperty itemNames = property.FindPropertyRelative("names");

        // Make sure output size matches output name size
        items.arraySize = itemNames.arraySize;

        for (int i = 0; i < itemNames.arraySize; i++)
        {
            // Get current rect height
            position.height = EditorGUI.GetPropertyHeight(items.GetArrayElementAtIndex(i), true);

            // Do property field, where name of field is name of output in the package
            EditorGUI.PropertyField(
                position, items.GetArrayElementAtIndex(i),
                new GUIContent(itemNames.GetArrayElementAtIndex(i).stringValue), true);

            // Update y value of the current rect
            position.y += position.height;
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        SerializedProperty outputs = property.FindPropertyRelative("items");
        float height = 0f;

        for (int i = 0; i < outputs.arraySize; i++)
        {
            height += EditorGUI.GetPropertyHeight(outputs.GetArrayElementAtIndex(i), true);
        }

        return height;
    }
}