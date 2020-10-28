using UnityEngine;
using UnityEngine.Events;

public class ConvertVector3ToVector2 : Function<Vector2>
{
    public Input<Vector3> input;

    protected override Vector2 GetValue()
    {
        return input.value;
    }
}
