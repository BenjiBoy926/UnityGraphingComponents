using UnityEditor;

public static class VariableEditor
{
    public static void OnInspectorGUI(SerializedObject serializedObject)
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("_variableName"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_defaultValue"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_onValueChanged"));

        serializedObject.ApplyModifiedProperties();
    }
}
