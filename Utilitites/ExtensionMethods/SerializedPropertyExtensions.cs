using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public static class SerializedPropertyExtensions
{
    public static IEnumerable<SerializedProperty> GetChildren(this SerializedProperty serializedProperty)
    {
        SerializedProperty currentProperty = serializedProperty.Copy();
        SerializedProperty nextSiblingProperty = serializedProperty.Copy();
        {
            nextSiblingProperty.Next(false);
        }

        if (currentProperty.Next(true))
        {
            do
            {
                if (SerializedProperty.EqualContents(currentProperty, nextSiblingProperty))
                    break;

                yield return currentProperty;
            }
            while (currentProperty.Next(false));
        }
    }

    public static void ResizeArray(this SerializedProperty property, int newSize)
    {
        if(property.arraySize < newSize)
        {
            for(int i = property.arraySize; i < newSize; i++)
            {
                property.InsertArrayElementAtIndex(i);
            }
        }
        else if(property.arraySize > newSize)
        {
            for(int i = (property.arraySize - 1); i >= newSize; i--)
            {
                property.DestroyArrayElement(i);
            }
        }
    }

    public static void DestroyArrayElement(this SerializedProperty property, int index)
    {
        int oldSize = property.arraySize;
        property.DeleteArrayElementAtIndex(index);
        if (property.arraySize == oldSize)
        {
            property.DeleteArrayElementAtIndex(index);
        }
    }
}
