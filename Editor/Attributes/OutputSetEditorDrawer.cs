using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(OutputSetEditorAttribute))]
public class OutputSetEditorDrawer : PropertyDrawer
{
    // METHODS
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (fieldInfo.FieldType == typeof(OutputSet))
        {
            OutputSetEditorAttribute drawerAttribute = attribute as OutputSetEditorAttribute;

            if (drawerAttribute != null)
            {
                if (drawerAttribute.type == OutputSetEditorType.Exposed)
                {
                    OnGUIFullEdit(position, property);
                }
                else
                {
                    OnGUIListsOnly(position, property);
                }
            }
            else EditorGUI.PropertyField(position, property);
        }
        else EditorGUI.PropertyField(position, property);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (fieldInfo.FieldType == typeof(OutputSet))
        {
            OutputSetEditorAttribute drawerAttribute = attribute as OutputSetEditorAttribute;

            if (drawerAttribute != null)
            {
                if (drawerAttribute.type == OutputSetEditorType.Exposed)
                {
                    return ComplexListEditor.GetPropertyHeight(property.FindPropertyRelative("_outputs"), label);
                }
                else
                {
                    SerializedProperty outputs = property.FindPropertyRelative("_outputs");
                    float height = 0f;

                    for(int i = 0; i < outputs.arraySize; i++)
                    {
                        height += EditorGUI.GetPropertyHeight(outputs.GetArrayElementAtIndex(i).FindPropertyRelative("_two"), true);
                    }

                    return height;
                }
            }
            else return EditorGUI.GetPropertyHeight(property, true);
        }
        else return EditorGUI.GetPropertyHeight(property, true);
    }

    // Allow full editing of names and lists
    private void OnGUIFullEdit(Rect position, SerializedProperty property)
    {
        ComplexListEditor.OnGUI(position, property.FindPropertyRelative("_outputs"), new GUIContent("Outputs"), false);
    }

    // Only allow editing of the lists, not the names
    private void OnGUIListsOnly(Rect position, SerializedProperty property)
    {
        SerializedProperty outputs = property.FindPropertyRelative("_outputs");
        SerializedProperty name;
        SerializedProperty list;

        // Set the array size to the names in the list in the attribute 
        OutputSetEditorAttribute editorAttribute = attribute as OutputSetEditorAttribute;
        if(editorAttribute != null)
        {
            outputs.ResizeArray(editorAttribute.names.Length);
        }

        for (int i = 0; i < editorAttribute.names.Length; i++)
        {
            name = outputs.GetArrayElementAtIndex(i).FindPropertyRelative("_one");
            list = outputs.GetArrayElementAtIndex(i).FindPropertyRelative("_two");

            // Set the name of the property to the name in the attribute
            name.stringValue = editorAttribute.names[i];

            // Do property field, where name of field is name of output in the package
            position.height = EditorGUI.GetPropertyHeight(list, true);            
            EditorGUI.PropertyField(position, list, new GUIContent(name.stringValue), true);
            position.y += position.height;
        }
    }
}