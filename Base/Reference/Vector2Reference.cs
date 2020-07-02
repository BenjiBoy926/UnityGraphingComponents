using UnityEngine;

[System.Serializable]
public class Vector2Reference : Reference<Vector2>
{
    [SerializeField]
    [Tooltip("Type of reference")]
    private ReferenceType type;

    [SerializeField]
    [Tooltip("Component used to get the int, in the case of a variable reference type")]
    private Vector2Variable component = null;

    [SerializeField]
    [Tooltip("Value in the reference")]
    private Vector2 value;

    public override Vector2 GetValue()
    {
        switch (type)
        {
            case ReferenceType.Value: return value;
            case ReferenceType.Reference: return component.GetValue();
            default: return value;
        }
    }

    public override Variable<Vector2> GetReference()
    {
        return component;
    }
}
