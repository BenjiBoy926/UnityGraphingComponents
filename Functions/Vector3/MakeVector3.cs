using UnityEngine;

public class MakeVector3 : Function<Vector3>
{
    public Input<float> x;
    public Input<float> y;
    public Input<float> z;

    protected override Vector3 GetValue()
    {
        return new Vector3(x.value, y.value, z.value);
    }
}
