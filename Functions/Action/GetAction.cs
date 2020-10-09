using UnityEngine;

public class GetAction : Function<Action>
{
    public Input<GameObject> input;

    public override Action Get()
    {
        return input.value.GetComponent<Action>();
    }
}
