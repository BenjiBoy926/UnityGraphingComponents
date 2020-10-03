using UnityEngine;
using UnityEngine.Events;

public class GetLocalScale : Function<Vector3>
{
    public Input<GameObject> input;

    public override Vector3 Get()
    {
        return input.value.transform.localScale;
    }
}
