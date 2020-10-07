using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(OutputPackage))]
public class OutputPackageDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Get subproperties
        SerializedProperty outputs = property.FindPropertyRelative("outputs");
        SerializedProperty outputNames = property.FindPropertyRelative("outputNames");
        Rect currentRect = new Rect(position);

        // Make sure output size matches output name size
        outputs.arraySize = outputNames.arraySize;

        for(int i = 0; i < outputNames.arraySize; i++)
        {
            // Get current rect height
            currentRect.height = EditorGUI.GetPropertyHeight(outputs.GetArrayElementAtIndex(i), true);

            // Do property field, where name of field is name of output in the package
            EditorGUI.PropertyField(
                currentRect, outputs.GetArrayElementAtIndex(i),
                new GUIContent(outputNames.GetArrayElementAtIndex(i).stringValue), true);

            // Update y value of the current rect
            currentRect.y += currentRect.height;
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        SerializedProperty outputs = property.FindPropertyRelative("outputs");
        float height = 0f;

        for(int i = 0; i < outputs.arraySize; i++)
        {
            height += EditorGUI.GetPropertyHeight(outputs.GetArrayElementAtIndex(i), true);
        }

        return height;
    }
}