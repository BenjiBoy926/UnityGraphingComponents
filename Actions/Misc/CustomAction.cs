using System.Collections.Generic;

public class CustomAction : Action
{
    // Output set of a custom action is fully editable
    [OutputSetEditor(OutputSetEditorType.Exposed)]
    public OutputSet _outputs;

    protected override TriggerSet triggers => throughTriggers;
    protected override OutputSet outputs => _outputs;
}
