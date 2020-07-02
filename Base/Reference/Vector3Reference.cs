using UnityEngine;
using System.Collections;

[System.Serializable]
public class Vector3Reference : Reference<Vector3>
{
    [SerializeField]
    [Tooltip("Type of reference")]
    private ReferenceType type;

    [SerializeField]
    [Tooltip("Component used to get the value, in the case of a variable reference type")]
    private Vector3Variable component = null;

    [SerializeField]
    [Tooltip("Value in the reference")]
    private Vector3 value;

    public override Vector3 GetValue()
    {
        switch (type)
        {
            case ReferenceType.Value: return value;
            case ReferenceType.Reference: return component.GetValue();
            default: return value;
        }
    }

    public override Variable<Vector3> GetReference()
    {
        return component;
    }
}
