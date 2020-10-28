using UnityEngine;
using UnityEngine.Events;

public class GetDeltaTime : Function<float>
{
    protected override float GetValue()
    {
        return Time.deltaTime;
    }
}
