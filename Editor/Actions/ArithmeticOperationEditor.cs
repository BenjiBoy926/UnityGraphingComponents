using UnityEditor;

public class ArithmeticOperationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SerializedProperty operation = serializedObject.FindProperty("operation");

        serializedObject.Update();

        // Edit the operation and the operator
        EditorGUILayout.PropertyField(operation);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_operator"));
        
        // If the operation is not increment or decrement, display the operand
        if(operation.enumValueIndex < 4)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("operand"));
        }

        EditorGUILayout.PropertyField(serializedObject.FindProperty("result"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("output"));

        serializedObject.ApplyModifiedProperties();
    }
}

[CustomEditor(typeof(IntOperation))]
[CanEditMultipleObjects]
public class IntOperationEditor : ArithmeticOperationEditor { }

[CustomEditor(typeof(FloatOperation))]
[CanEditMultipleObjects]
public class FloatOperationEditor : ArithmeticOperationEditor { }