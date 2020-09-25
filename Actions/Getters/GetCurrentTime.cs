using UnityEngine;

public class GetCurrentTime : BasicGetterAction<float>
{
    public override float Get()
    {
        return Time.time;
    }
}
