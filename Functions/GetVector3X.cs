using UnityEngine;

public class GetVector3X : Function<float>
{
    public Input<Vector3> input;

    public override float Get()
    {
        return input.value.x;
    }
}
