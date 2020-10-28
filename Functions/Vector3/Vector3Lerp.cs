using UnityEngine;

public class Vector3Lerp : Function<Vector3>
{
    public Input<Vector3> min;
    public Input<Vector3> max;
    public Input<float> interpolator;

    protected override Vector3 GetValue()
    {
        return Vector3.Lerp(min.value, max.value, interpolator.value);
    }
}
