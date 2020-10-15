using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(UseFoldoutInEditorAttribute))]
public class UseFoldoutInEditorDrawer : PropertyDrawer
{
    // METHODS
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.hasChildren)
        {
            UseFoldoutInEditorAttribute useFoldout = attribute as UseFoldoutInEditorAttribute;

            if (useFoldout != null)
            {
                if (useFoldout.foldout)
                {
                    OnGUIWithFoldout(position, property, label);
                }
                else OnGUIChildren(position, property);
            }
            else EditorGUI.PropertyField(position, property, true);
        }
        else EditorGUI.PropertyField(position, property, true);
    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (property.hasChildren)
        {
            UseFoldoutInEditorAttribute useFoldout = attribute as UseFoldoutInEditorAttribute;

            if (useFoldout != null)
            {
                if (useFoldout.foldout)
                {
                    float height = GraphingEditorUtility.standardControlHeight;
                    if (property.isExpanded)
                    {
                        height += GetChildrenHeight(property);
                    }
                    return height;
                }
                else return GetChildrenHeight(property);
            }
            else return EditorGUI.GetPropertyHeight(property, true);
        }
        else return EditorGUI.GetPropertyHeight(property, true);
    }

    // HELPERS
    private void OnGUIWithFoldout(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect foldoutPosition = new Rect(position.position, new Vector2(position.width, GraphingEditorUtility.standardControlHeight));
        property.isExpanded = EditorGUI.Foldout(foldoutPosition, property.isExpanded, label);

        if (property.isExpanded)
        {
            position.y += GraphingEditorUtility.standardControlHeight;
            position.height -= GraphingEditorUtility.standardControlHeight;
            OnGUIChildren(position, property);
        }
    }

    private void OnGUIChildren(Rect position, SerializedProperty property)
    {
        foreach(SerializedProperty child in property.GetChildren())
        {
            position.height = EditorGUI.GetPropertyHeight(child, true);
            EditorGUI.PropertyField(position, child, true);
            position.y += position.height;
        }
    }

    private float GetChildrenHeight(SerializedProperty property)
    {
        float height = 0f;
        foreach(SerializedProperty child in property.GetChildren())
        {
            height += EditorGUI.GetPropertyHeight(child, true);
        }
        return height;
    }
}