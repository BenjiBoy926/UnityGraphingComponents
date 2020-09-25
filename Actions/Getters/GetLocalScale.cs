using UnityEngine;
using UnityEngine.Events;

public class GetLocalScale : BasicGetterAction<Vector3>
{
    public Input<GameObject> input;

    public override Vector3 Get()
    {
        return input.value.transform.localScale;
    }
}
