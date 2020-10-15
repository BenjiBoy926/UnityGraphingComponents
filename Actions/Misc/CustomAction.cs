using UnityEngine;
using System.Collections.Generic;

public class CustomAction : Action
{
    // Attribute that allows more editing
    [OutputSetEditor(OutputSetEditorType.Exposed)]
    public OutputSet _outputs;

    public override TriggerSet triggers
    {
        get
        {
            Dictionary<string, Trigger> keyValuePairs = new Dictionary<string, Trigger>();
            foreach(Pair<string, OutputList> pair in _outputs.outputs)
            {
                keyValuePairs.Add(pair.one, new Trigger(() => Output(pair.one)));
            }
            return new TriggerSet(keyValuePairs);
        }
    }
    protected override OutputSet outputs => _outputs;
}
