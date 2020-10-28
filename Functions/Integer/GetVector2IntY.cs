using UnityEngine;
using System.Collections;

public class GetVector2IntY : Function<int>
{
    public Input<Vector2Int> input;

    protected override int GetValue()
    {
        return input.value.y;
    }
}
