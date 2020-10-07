using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Output))]
public class OutputDrawer : PropertyDrawer
{
    // OVERRIDES
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect content = EditorGUI.PrefixLabel(position, label);

        int oldIndent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        float width = content.width / 2f;
        Rect actionRect = new Rect(content.position, new Vector2(width, content.height));
        Rect triggerNameRect = new Rect(content.x + width, content.y, width, content.height);

        // Edito the action and the trigger selector
        EditorGUI.PropertyField(actionRect, property.FindPropertyRelative("action"), GUIContent.none);
        OnGUITriggerSelector(triggerNameRect, property);

        EditorGUI.indentLevel = oldIndent;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return GraphingEditorUtility.standardControlHeight;
    }

    // HELPERS
    private void OnGUITriggerSelector(Rect rect, SerializedProperty property)
    {
        SerializedProperty triggerName = property.FindPropertyRelative("triggerName");
        Object actionObject = property.FindPropertyRelative("action").objectReferenceValue;
        
        if(actionObject != null)
        {
            // Get the object reference as an action
            Action action = (Action)actionObject;
            int totalTriggers = action.triggers.triggers.Count;
            string[] availableTriggers = new string[totalTriggers];
            
            // Copy trigger names into the array
            action.triggers.triggers.Keys.CopyTo(availableTriggers, 0);

            // Setup a popup editor
            int popupIndex = System.Array.FindIndex(availableTriggers, t => triggerName.stringValue == t);

            // If current trigger name is not in the array, set index to 0
            if(popupIndex < 0)
            {
                popupIndex = 0;
            }

            popupIndex = EditorGUI.Popup(rect, popupIndex, availableTriggers);

            // Assign selection back into property
            triggerName.stringValue = availableTriggers[popupIndex];
        }
        else
        {
            triggerName.stringValue = "";
            EditorGUI.Popup(rect, 0, new string[] { "" });
        }
    }
}