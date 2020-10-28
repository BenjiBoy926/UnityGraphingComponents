public class AddInts : Function<int>
{
    public Input<int> int1;
    public Input<int> int2;

    protected override int GetValue()
    {
        return int1.value + int2.value;
    }
}