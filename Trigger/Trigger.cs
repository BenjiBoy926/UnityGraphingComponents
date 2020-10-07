public class Trigger
{
    // FIELDS
    private System.Action function;

    // CONSTRUCTORS
    public Trigger(System.Action f)
    {
        function = f;
    }

    // METHODS
    public void Invoke()
    {
        function.Invoke();
    }
}
