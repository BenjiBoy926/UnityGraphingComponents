using UnityEngine;
using UnityEngine.Events;

public class GetDeltaTime : BasicGetterAction<float>
{
    public override float Get()
    {
        return Time.deltaTime;
    }
}
