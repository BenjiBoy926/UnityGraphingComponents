using UnityEngine;
using UnityEngine.Events;

public class GetLocalScale : Function<Vector3>
{
    public Input<GameObject> input;

    protected override Vector3 GetValue()
    {
        return input.value.transform.localScale;
    }
}
