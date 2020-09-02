using UnityEditor;

[CustomEditor(typeof(IntVariable))]
[CanEditMultipleObjects]
public class IntVariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        VariableEditor.OnInspectorGUI(serializedObject);
    }
}
