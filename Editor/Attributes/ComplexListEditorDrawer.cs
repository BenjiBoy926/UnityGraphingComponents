using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ComplexListEditorAttribute))]
public class ComplexListEditorDrawer : PropertyDrawer
{
    int itemSelected = 0;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect foldoutRect = new Rect(position.position, new Vector2(position.width, GraphingEditorUtility.standardControlHeight));
        property.isExpanded = EditorGUI.Foldout(foldoutRect, property.isExpanded, label);

        // If property is expanded, do the gui list
        if(property.isExpanded)
        {
            OnGUIList(position, property);
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (property.isArray)
        {
            return GetPropertyArrayHeight(property);
        }
        else return EditorGUI.GetPropertyHeight(property, true);
    }

    // Get the height of the property, assuming it is an array
    private float GetPropertyArrayHeight(SerializedProperty property)
    {
        if (property.isExpanded)
        {
            float height = GraphingEditorUtility.standardControlHeight * 2f;
            for (int i = 0; i < property.arraySize; i++)
            {
                height += EditorGUI.GetPropertyHeight(property.GetArrayElementAtIndex(i), true);
            }
            return height;
        }
        else return GraphingEditorUtility.standardControlHeight;
    }

    private void OnGUIList(Rect position, SerializedProperty property)
    {

    }
}