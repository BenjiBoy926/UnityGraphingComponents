using UnityEngine;

[System.Serializable]
public class IntConversion
{
    // TYPEDEFS
    public enum Conversion
    {
        FromBool, FromFloat, FromString, FromVector
    }

    // FIELDS
    [SerializeField]
    private Conversion conversion;
    [SerializeField]
    private Input<bool> boolInput;
    [SerializeField]
    private IntFromFloat fromFloat;
    [SerializeField]
    private Input<string> stringInput;
    [SerializeField]
    private IntFromVector fromVector;
    
    // PROPERTIES
    public int value
    {
        get
        {
            switch(conversion)
            {
                case Conversion.FromBool: return boolInput.value ? 1 : 0;
                case Conversion.FromFloat: return fromFloat.value;
                case Conversion.FromString: return int.Parse(stringInput.value);
                case Conversion.FromVector: return fromVector.value;
                default: return default;
            }
        }
    }
}
