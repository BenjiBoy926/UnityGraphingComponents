using UnityEngine;

public class FloatAbsoluteValue : Function<float>
{
    public Input<float> input;

    public override float Get()
    {
        return Mathf.Abs(input.value);
    }
}
