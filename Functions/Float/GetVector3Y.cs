using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetVector3Y : Function<float>
{
    public Input<Vector3> input;

    protected override float GetValue()
    {
        return input.value.y;
    }
}
