using UnityEngine;
using System.Text;

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
        lastInvokedOutput = name;
        outputs.Invoke(name, this);
    }
    public override string ToString()
    {
        return GetType().Name + " (at " + gameObject.Path() + ")";
    }
}
