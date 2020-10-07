public class AddInts : Function<int>
{
    public Input<int> int1;
    public Input<int> int2;

    public override int Get()
    {
        return int1.value + int2.value;
    }
}