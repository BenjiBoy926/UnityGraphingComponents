public class InitializeEventsAction : Action
{
    // FIELDS
    [OutputSetEditor("Awake", "Start")]
    public OutputSet _outputs;

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
