public class InitializeEventsAction : Action
{
    // FIELDS
    public OutputSet _outputs = new OutputSet("Awake", "Start");

    // PROPERTIES
    protected override OutputSet outputs => _outputs;

    // METHODS
    private void Awake()
    {
        Output("Awake");
    }
    private void Start()
    {
        Output("Start");
    }
}
