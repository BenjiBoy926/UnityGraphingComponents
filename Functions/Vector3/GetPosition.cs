using UnityEngine;

public class GetPosition : Function<Vector3>
{
    public Space space;
    public Input<GameObject> input;

    protected override Vector3 GetValue()
    {
        if (space == Space.World)
        {
            return input.value.transform.position;
        }
        else return input.value.transform.localPosition;
    }
}
