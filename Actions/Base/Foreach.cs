public class Foreach<Type> : Action
{
    // FIELDS
    // PUBLIC
    // inputs
    public Input<Type[]> items;

    // results
    public Result<Type> currentValue;
    public Result<int> currentIndex;

    // outputs
    public OutputPackage _outputs = new OutputPackage("Start", "Step", "Stop");

    // PRIVATE
    private Type current;

    // PROPERTIES
    public override TriggerPackage triggers => new TriggerPackage(new TriggerPackage.Item("Invoke", Invoke));
    public override OutputPackage outputs => _outputs;

    // METHODS
    public void Invoke()
    {
        Type[] itemsStored = items.value;

        outputs.Invoke("Start");

        for(int i = 0; i < itemsStored.Length; i++)
        {
            // Set current value
            currentValue.value = itemsStored[i];
            current = itemsStored[i];

            // Set current index
            currentIndex.value = i;

            // Invoke step function
            outputs.Invoke("Step");
        }

        outputs.Invoke("Stop");
    }
}
