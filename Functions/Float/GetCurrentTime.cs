using UnityEngine;

public class GetCurrentTime : Function<float>
{
    protected override float GetValue()
    {
        return Time.time;
    }
}
