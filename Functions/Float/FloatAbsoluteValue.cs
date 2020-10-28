using UnityEngine;

public class FloatAbsoluteValue : Function<float>
{
    public Input<float> input;

    protected override float GetValue()
    {
        return Mathf.Abs(input.value);
    }
}
