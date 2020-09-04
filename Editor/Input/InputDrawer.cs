using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Input<>))]
public class InputDrawer : PropertyDrawer
{
    private const float VALUE_BUFFER = 12f;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect prefixPosition = new Rect(position.position, new Vector2(position.width, GraphingEditorUtility.standardControlHeight));
        Rect content = EditorGUI.PrefixLabel(prefixPosition, label);

        // Display the type drawer
        ReferenceDrawer.OnGUIType(content, property);

        if (property.FindPropertyRelative("type").enumValueIndex == 0)
        {
            OnGUIValue(position, content, property);
        }
        else
        {
            ReferenceDrawer.OnGUIReference(content, property, 1);
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        SerializedProperty value = property.FindPropertyRelative("directValue");
        SerializedProperty type = property.FindPropertyRelative("type");
        float valueHeight = EditorGUI.GetPropertyHeight(value, true);

        if (type.enumValueIndex == 1 || valueHeight <= GraphingEditorUtility.standardControlHeight)
        {
            return GraphingEditorUtility.standardControlHeight;
        }
        else return GraphingEditorUtility.standardControlHeight + valueHeight;
    }

    private void OnGUIValue(Rect position, Rect content, SerializedProperty property)
    {
        SerializedProperty value = property.FindPropertyRelative("directValue");
        float height = EditorGUI.GetPropertyHeight(value, true);

        if (height <= GraphingEditorUtility.standardControlHeight)
        {
            Rect rect = new Rect(
                content.x + ReferenceDrawer.TYPE_WIDTH + VALUE_BUFFER, 
                content.y, 
                content.width - ReferenceDrawer.TYPE_WIDTH - VALUE_BUFFER, 
                height);
            EditorGUI.PropertyField(rect, value, GUIContent.none, true);
        }
        else
        {
            Rect rect = new Rect(
                position.x, 
                position.y + GraphingEditorUtility.standardControlHeight,
                position.width, 
                height);
            EditorGUI.PropertyField(rect, value, true);
        }
    }
}
