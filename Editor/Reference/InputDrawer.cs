using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Input<>))]
public class InputDrawer : PropertyDrawer
{
    private bool mainFoldout;
    private bool advancedFoldout;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        System.Type genericType = fieldInfo.FieldType.GetGenericArguments()[0];
        
        if(genericType.IsSameAsOrSubclassOf(typeof(GameObject)) || 
            genericType.IsSameAsOrSubclassOf(typeof(Component)))
        {
            ReferenceDrawer.OnGUI(position, property, label, ReferenceDrawerType.Input, 
                ReferenceDataType.GameObjectOrComponent, ref mainFoldout, ref advancedFoldout);
        }
        else
        {
            ReferenceDrawer.OnGUI(position, property, label, ReferenceDrawerType.Input, 
                ReferenceDataType.NeitherGameObjectNorComponent, ref mainFoldout, ref advancedFoldout);
        }
        
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        System.Type genericType = fieldInfo.FieldType.GetGenericArguments()[0];

        if (genericType.IsSameAsOrSubclassOf(typeof(GameObject)) || 
            genericType.IsSameAsOrSubclassOf(typeof(Component)))
        {
            return ReferenceDrawer.GetPropertyHeight(property, label, ReferenceDrawerType.Input,
                ReferenceDataType.GameObjectOrComponent, mainFoldout, advancedFoldout);
        }
        else
        {
            return ReferenceDrawer.GetPropertyHeight(property, label, ReferenceDrawerType.Input,
                ReferenceDataType.NeitherGameObjectNorComponent, mainFoldout, advancedFoldout);
        }
    }
}
