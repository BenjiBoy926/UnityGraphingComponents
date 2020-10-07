using UnityEngine;
using System.Collections;

[System.Serializable]
public class IntFromFloat
{
    // TYPEDEFS
    public enum Function
    {
        Floor, Ceil, Round
    }

    // FIELDS
    [SerializeField]
    private Function function;
    [SerializeField]
    private Input<float> input;

    // PROPERTIES
    public int value
    {
        get
        {
            switch(function)
            {
                case Function.Floor: return Mathf.FloorToInt(input.value);
                case Function.Ceil: return Mathf.CeilToInt(input.value);
                case Function.Round: return Mathf.RoundToInt(input.value);
                default: return default;
            }
        }
    }

    // CONSTRUCTORS
    public IntFromFloat(Function f, Input<float> i)
    {
        function = f;
        input = i;
    }
}
