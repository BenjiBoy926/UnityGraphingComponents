using UnityEngine;
using UnityEngine.Events;

public class MakeVector2Int : Function<Vector2Int>
{
    public Input<int> x;
    public Input<int> y;

    protected override Vector2Int GetValue()
    {
        return new Vector2Int(x.value, y.value);
    }
}
