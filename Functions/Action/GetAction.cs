using UnityEngine;

public class GetAction : Function<Action>
{
    public Input<GameObject> input;

    protected override Action GetValue()
    {
        return input.value.GetComponent<Action>();
    }
}
