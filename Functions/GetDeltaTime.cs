using UnityEngine;
using UnityEngine.Events;

public class GetDeltaTime : Function<float>
{
    public override float Get()
    {
        return Time.deltaTime;
    }
}
