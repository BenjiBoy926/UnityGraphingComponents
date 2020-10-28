using UnityEngine;
using System.Collections.Generic;

public class Action : MonoBehaviour
{
    // CONSTANTS
    public const string DEFAULT_TRIGGER_NAME = "Invoke";
    public const string DEFAULT_OUTPUT_NAME = "Output";

    // FIELDS
    private History history;
    private string lastInvokedTrigger = "<none>";
    private string lastInvokedOutput = "<none>";

    // PROPERTIES
    public string[] triggerNames
    {
        get => triggers.triggerNames;
    }
    protected virtual TriggerSet triggers
    {
        get => throw new System.NotImplementedException("Class " + GetType().Name +
            " does not override property \"triggers\" where overriding is required");
    }
    protected virtual OutputSet outputs
    {
        get => throw new System.NotImplementedException("Class " + GetType().Name +
            " does not override property \"outputs\" where overriding is required");
    }
    // Return a set of triggers where each trigger has the same name as an output,
    // and the trigger action calls the output
    protected TriggerSet throughTriggers
    {
        get
        {
            Dictionary<string, Trigger> keyValuePairs = new Dictionary<string, Trigger>();
            foreach (Pair<string, OutputList> pair in outputs.outputs)
            {
                keyValuePairs.Add(pair.one, new Trigger(() => Output(pair.one)));
            }
            return new TriggerSet(keyValuePairs);
        }
    }

    // METHODS
    public void Trigger(string name = DEFAULT_TRIGGER_NAME, History parent = null)
    {
        history = new History(parent, this);
        lastInvokedTrigger = name;
        lastInvokedOutput = "<none>";

        // Don't let the action trigger itself
        if(history.IsCircular())
        {
            history.LogError(new System.StackOverflowException("Self-trigger is not allowed (" + ToString() + ")"));
            return;
        }

        // Try to invoke the trigger
        try
        {
            triggers.Invoke(name);
        }
        catch(System.Exception e)
        {
            history.LogError(e);
        }
    }
    protected void Output(string name = DEFAULT_OUTPUT_NAME)
    {
        outputs.Invoke(name, history);
    }
    public override string ToString()
    {
        return GetType().Name + " (at " + gameObject.Path() + ")";
    }
}
