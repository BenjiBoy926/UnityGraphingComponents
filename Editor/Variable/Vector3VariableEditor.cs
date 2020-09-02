using UnityEditor;

[CustomEditor(typeof(Vector3Variable))]
[CanEditMultipleObjects]
public class Vector3VariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        VariableEditor.OnInspectorGUI(serializedObject);
    }
}
