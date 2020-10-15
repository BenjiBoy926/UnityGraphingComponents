using UnityEngine;
using System.Collections;

public class UseFoldoutInEditorAttribute : PropertyAttribute
{
    // PROPERTIES
    public bool foldout { get; private set; }

    // CONSTRUCTORS
    public UseFoldoutInEditorAttribute(bool f)
    {
        foldout = f;
    }
}
