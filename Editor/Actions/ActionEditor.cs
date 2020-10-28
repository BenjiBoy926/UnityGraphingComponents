using UnityEngine;
using UnityEditor;

public class ActionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Action action = serializedObject.targetObject as Action;

        // Make sure the action was found
        if(action != null)
        {
            GUILayout.BeginHorizontal();

            // Create a button for each trigger name that triggers the action when pressed
            for(int i = 0; i < action.triggerNames.Length; i++)
            {
                if(GUILayout.Button(action.triggerNames[i]))
                {
                    action.Trigger(action.triggerNames[i]);
                }
            }

            GUILayout.EndHorizontal();
        }

        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(CustomAction))]
public class CustomActionEditor : ActionEditor { }
[CustomEditor(typeof(InterpolateVector2))]
public class InterpolateVector2Editor : ActionEditor { }