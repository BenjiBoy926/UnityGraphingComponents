using UnityEditor;

[CustomEditor(typeof(Vector2Variable))]
[CanEditMultipleObjects]
public class Vector2VariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        VariableEditor.OnInspectorGUI(serializedObject);
    }
}
