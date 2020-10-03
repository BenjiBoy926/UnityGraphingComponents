using UnityEngine;
using UnityEditor;

//[CustomPropertyDrawer(typeof(IntFunction))]
public class IntFunctionDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        base.OnGUI(position, property, label);
    }
}