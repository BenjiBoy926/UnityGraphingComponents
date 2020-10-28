using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class ScaleVector3 : Function<Vector3>
{
    public Input<Vector3> input;
    public Input<float> scalar;

    protected override Vector3 GetValue()
    {
        return input.value * scalar.value;
    }
}
