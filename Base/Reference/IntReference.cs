using UnityEngine;
using System.Collections;

[System.Serializable]
public class IntReference : Reference<int>
{
    [SerializeField]
    [Tooltip("Type of reference")]
    private ReferenceType type;

    [SerializeField]
    [Tooltip("Component used to get the int, in the case of a variable reference type")]
    private IntVariable component = null;

    [SerializeField]
    [Tooltip("Value in the reference")]
    private int value;

    public override int GetValue()
    {
        switch(type)
        {
            case ReferenceType.Value: return value;
            case ReferenceType.Reference: return component.GetValue();
            default: return value;
        }
    }

    public override Variable<int> GetReference()
    {
        return component;
    }
}
