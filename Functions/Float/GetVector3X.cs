using UnityEngine;

public class GetVector3X : Function<float>
{
    public Input<Vector3> input;

    protected override float GetValue()
    {
        return input.value.x;
    }
}
