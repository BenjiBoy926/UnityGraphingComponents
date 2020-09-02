using UnityEditor;

[CustomEditor(typeof(FloatVariable))]
[CanEditMultipleObjects]
public class FloatVariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        VariableEditor.OnInspectorGUI(serializedObject);
    }
}
