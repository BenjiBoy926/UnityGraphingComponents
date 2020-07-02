using UnityEngine;
using System.Collections;

[System.Serializable]
public class FloatReference : Reference<float>
{
    [SerializeField]
    [Tooltip("Type of reference")]
    private ReferenceType type;

    [SerializeField]
    [Tooltip("Component used to get the int, in the case of a variable reference type")]
    private FloatVariable component = null;

    [SerializeField]
    [Tooltip("Value in the reference")]
    private float value;

    public override float GetValue()
    {
        switch (type)
        {
            case ReferenceType.Value: return value;
            case ReferenceType.Reference: return component.GetValue();
            default: return value;
        }
    }

    public override Variable<float> GetReference()
    {
        return component;
    }
}
