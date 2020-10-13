using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Output))]
public class OutputDrawer : PropertyDrawer
{
    // OVERRIDES
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect rect = new Rect(position.position, new Vector2(position.width, GraphingEditorUtility.standardControlHeight));
        property.isExpanded = EditorGUI.Foldout(rect, property.isExpanded, label);
        rect.y += GraphingEditorUtility.standardControlHeight;

        if (property.isExpanded)
        {
            // Edit the action input
            EditorGUI.PropertyField(rect, property.FindPropertyRelative("action"), true);
            rect.y += GraphingEditorUtility.standardControlHeight;

            OnGUITriggerSelector(rect, property);
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (property.isExpanded)
        {
            return GraphingEditorUtility.standardControlHeight * 3f;
        }
        else return GraphingEditorUtility.standardControlHeight;
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
            TriggerSet triggers = action.triggers;

            if (triggers != null)
            {
                int totalTriggers = triggers.triggers.Count;

                if (totalTriggers > 0)
                {
                    string[] availableTriggers = new string[totalTriggers];

                    // Copy trigger names into the array
                    action.triggers.triggers.Keys.CopyTo(availableTriggers, 0);

                    // Setup a popup editor
                    int popupIndex = System.Array.FindIndex(availableTriggers, t => triggerName.stringValue == t);

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
                    popupIndex = EditorGUI.Popup(rect, popupIndex, availableTriggers);
                    triggerName.stringValue = availableTriggers[popupIndex];

                    // Restore old indent
                    EditorGUI.indentLevel = oldIndent;
                }
                else OnGUIEmptyPopup(rect, triggerName);
            }
            else OnGUIEmptyPopup(rect, triggerName);

        }
        else OnGUIEmptyPopup(rect, triggerName);
    }

    private void OnGUIEmptyPopup(Rect rect, SerializedProperty triggerName)
    {
        triggerName.stringValue = "";
        rect = EditorGUI.PrefixLabel(rect, new GUIContent("Trigger Name"));
        EditorGUI.Popup(rect, 0, new string[] { "" });
    }
}