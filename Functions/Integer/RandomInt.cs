using UnityEngine;
using UnityEngine.Events;

public class RandomInt : Function<int>
{
    public Input<int> min;
    public Input<int> max;

    protected override int GetValue()
    {
        return Random.Range(min.value, max.value);
    }
}
