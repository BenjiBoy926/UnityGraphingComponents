using UnityEngine;

[System.Serializable]
public class StringReference : Reference<string>
{
    [SerializeField]
    [Tooltip("Type of reference")]
    private ReferenceType type;

    [SerializeField]
    [Tooltip("Component used to get the int, in the case of a variable reference type")]
    private StringVariable component = null;

    [SerializeField]
    [Tooltip("Value in the reference")]
    private string value;

    public override string GetValue()
    {
        switch (type)
        {
            case ReferenceType.Value: return value;
            case ReferenceType.Reference: return component.GetValue();
            default: return value;
        }
    }

    public override Variable<string> GetReference()
    {
        return component;
    }
}
