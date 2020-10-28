public class InitializeEventsAction : Action
{
    // FIELDS
    [OutputSetEditor("Awake", "Start")]
    public OutputSet _outputs;

    // PROPERTIES
    protected override TriggerSet triggers => throughTriggers;
    protected override OutputSet outputs => _outputs;

    // METHODS
    private void Awake()
    {
        Trigger("Awake", null);
    }
    private void Start()
    {
        Trigger("Start", null);
    }
}
