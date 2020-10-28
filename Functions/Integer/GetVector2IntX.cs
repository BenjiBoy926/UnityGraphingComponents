using UnityEngine;
using System.Collections;

public class GetVector2IntX : Function<int>
{
    public Input<Vector2Int> input;

    protected override int GetValue()
    {
        return input.value.x;
    }
}
