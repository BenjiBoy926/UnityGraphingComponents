using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseInput
{
    // TYPEDEFS
    public enum InputType
    {
        Value, Variable, Function
    }

    // FIELDS
    [SerializeField]
    protected InputType type;
}
