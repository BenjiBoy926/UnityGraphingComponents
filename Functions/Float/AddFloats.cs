public class AddFloats : Function<float>
{
    public Input<float> float1;
    public Input<float> float2;

    protected override float GetValue()
    {
        return float1.value + float2.value;
    }
}
