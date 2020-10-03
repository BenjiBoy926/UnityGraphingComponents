using UnityEngine;

[System.Serializable]
public class IntFunction
{
    public enum Function
    {
        Abs, Clamp
    }

    [SerializeField]
    private Function type;

    [SerializeField]
    private Input<int> integer1;
    [SerializeField]
    private Input<int> integer2;
    [SerializeField]
    private Input<int> integer3;

    public int value
    {
        get
        {
            switch(type)
            {
                case Function.Abs: return Mathf.Abs(integer1.value);
                case Function.Clamp: return Mathf.Clamp(integer1.value, integer2.value, integer3.value);
                default: return default;
            }
        }
    }
}
