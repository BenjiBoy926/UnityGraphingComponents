using UnityEngine;
using System.Collections;

public class GetVector2IntY : Function<int>
{
    public Input<Vector2Int> input;

    public override int Get()
    {
        return input.value.y;
    }
}
