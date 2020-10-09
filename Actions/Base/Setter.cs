public class Setter<Type> : Action
{
    // FIELDS
    // PUBLIC
    // inputs
    public Input<Type> input;

    // results
    public Result<Type> result;

    // outputs
    public OutputPackage _outputs = new OutputPackage("Output");

    // PROPERTIES
    public override TriggerPackage triggers => new TriggerPackage(new TriggerPackage.Item("Invoke", Invoke));
    public override OutputPackage outputs => _outputs;

    public void Invoke()
    {
        result.value = input.value;
        _outputs.Invoke("Output");
    }
}
