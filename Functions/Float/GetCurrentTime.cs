using UnityEngine;

public class GetCurrentTime : Function<float>
{
    public override float Get()
    {
        return Time.time;
    }
}
