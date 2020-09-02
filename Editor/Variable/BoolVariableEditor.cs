using UnityEditor;

[CustomEditor(typeof(BoolVariable))]
[CanEditMultipleObjects]
public class BoolVariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        VariableEditor.OnInspectorGUI(serializedObject);
    }
}
