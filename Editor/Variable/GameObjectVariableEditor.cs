using UnityEditor;

[CustomEditor(typeof(GameObjectVariable))]
[CanEditMultipleObjects]
public class GameObjectVariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        VariableEditor.OnInspectorGUI(serializedObject);
    }
}
