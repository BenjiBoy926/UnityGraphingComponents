using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameObjectReference : Reference<GameObject>
{
    [SerializeField]
    [Tooltip("Type of reference")]
    private ReferenceType type;

    [SerializeField]
    [Tooltip("Component used to get the int, in the case of a variable reference type")]
    private GameObjectVariable component = null;

    [SerializeField]
    [Tooltip("Value in the reference")]
    private GameObject value;

    public override GameObject GetValue()
    {
        switch (type)
        {
            case ReferenceType.Value: return value;
            case ReferenceType.Reference: return component.GetValue();
            default: return value;
        }
    }

    public override Variable<GameObject> GetReference()
    {
        return component;
    }
}
