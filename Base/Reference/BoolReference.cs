using UnityEngine;
using System.Collections;

[System.Serializable]
public class BoolReference : Reference<bool>
{
    [SerializeField]
    [Tooltip("Type of reference")]
    private ReferenceType type;

    [SerializeField]
    [Tooltip("Component used to get the int, in the case of a variable reference type")]
    private BoolVariable component = null;

    [SerializeField]
    [Tooltip("Value in the reference")]
    private bool value;

    public override bool GetValue()
    {
        switch (type)
        {
            case ReferenceType.Value: return value;
            case ReferenceType.Reference: return component.GetValue();
            default: return value;
        }
    }

    public override Variable<bool> GetReference()
    {
        return component;
    }
}
