using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Output))]
public class OutputDrawer : PropertyDrawer
{
    // OVERRIDES
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        position.height = GraphingEditorUtility.standardControlHeight;

        // Edit the action input
        EditorGUI.PropertyField(position, property.FindPropertyRelative("action"), true);
        position.y += GraphingEditorUtility.standardControlHeight;

        OnGUITriggerSelector(position, property);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return GraphingEditorUtility.standardControlHeight * 2f;
    }

    // HELPERS
    private void OnGUITriggerSelector(Rect rect, SerializedProperty property)
    {
        int inputType = property.FindPropertyRelative("action").FindPropertyRelative("type").enumValueIndex;

        if(inputType == 0)
        {
            OnGUITriggerPopup(rect, property);
        }
        else
        {
            EditorGUI.PropertyField(rect, property.FindPropertyRelative("triggerName"));
        }
    }

    private void OnGUITriggerPopup(Rect rect, SerializedProperty property)
    {
        SerializedProperty triggerName = property.FindPropertyRelative("triggerName");
        Object actionObject = property.FindPropertyRelative("action").FindPropertyRelative("_value").objectReferenceValue;

        if (actionObject != null)
        {
            // Get the object reference as an action
            Action action = (Action)actionObject;

            if (action.triggerNames.Length > 0)
            {
                // Setup a popup editor
                int popupIndex = System.Array.FindIndex(action.triggerNames, t => triggerName.stringValue == t);

                // If current trigger name is not in the array, set index to 0
                if (popupIndex < 0)
                {
                    popupIndex = 0;
                }

                // Put the prefix
                rect = EditorGUI.PrefixLabel(rect, new GUIContent("Trigger Name"));

                // Push old indent
                int oldIndent = EditorGUI.indentLevel;
                EditorGUI.indentLevel = 0;

                // Edit trigger string and assign it
                popupIndex = EditorGUI.Popup(rect, popupIndex, action.triggerNames);
                triggerName.stringValue = action.triggerNames[popupIndex];

                // Restore old indent
                EditorGUI.indentLevel = oldIndent;
            }
            else EditorGUI.PropertyField(rect, property.FindPropertyRelative("triggerName"));
        }
        else EditorGUI.PropertyField(rect, property.FindPropertyRelative("triggerName"));
    }
}