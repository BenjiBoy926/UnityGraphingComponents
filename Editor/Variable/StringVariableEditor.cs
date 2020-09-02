using UnityEditor;

[CustomEditor(typeof(StringVariable))]
[CanEditMultipleObjects]
public class StringVariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        VariableEditor.OnInspectorGUI(serializedObject);
    }
}
