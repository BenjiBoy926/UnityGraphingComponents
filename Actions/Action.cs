using UnityEngine;
using System.Text;

public class Action : MonoBehaviour
{
    // CONSTANTS
    public const string DEFAULT_TRIGGER_NAME = "Invoke";
    public const string DEFAULT_OUTPUT_NAME = "Output";

    // FIELDS
    private Action lastInvokingAction;
    private string lastInvokedTrigger = "<none>";
    private string lastInvokedOutput = "<none>";

    // PROPERTIES
    public virtual TriggerSet triggers
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
    public void Trigger(string name = DEFAULT_TRIGGER_NAME, Action invokingAction = null)
    {
        // Don't let the action trigger itself
        if(invokingAction == this)
        {
            HandleTriggerError(new System.StackOverflowException("Self-trigger is not allowed (" + ToString() + ")"));
            return;
        }

        // Set the previous invoking action
        lastInvokingAction = invokingAction;
        lastInvokedTrigger = name;

        // Try to invoke the trigger
        try
        {
            triggers.Invoke(name);
        }
        catch(System.Exception e)
        {
            HandleTriggerError(e);
        }
    }
    protected void Output(string name = DEFAULT_OUTPUT_NAME)
    {
        lastInvokedOutput = name;
        outputs.Invoke(name, this);
    }

    // HELPERS
    private void HandleTriggerError(System.Exception e)
    {
        // Log the "smart trace" and the stack trace
        Debug.LogError(
            e.GetType().Name + ": " + e.Message + System.Environment.NewLine + System.Environment.NewLine +
            "Smart trace:" + System.Environment.NewLine +
            SmartTrace() + System.Environment.NewLine +
            "Stack trace:" + System.Environment.NewLine +
            e.StackTrace);
    }

    // Build a "Smart Trace" from this action 
    // all the way back to an action which had no action as its trigger
    public string SmartTrace()
    {
        StringBuilder builder = new StringBuilder(ToStringWithHistory(false));
        Action current = lastInvokingAction;

        // Append the newline
        builder.Append(System.Environment.NewLine);

        while(current != null)
        {
            // Append the history of the current action
            builder.Append(current.ToStringWithHistory());
            builder.Append(System.Environment.NewLine);

            // Update current action
            current = current.lastInvokingAction;
        }

        return builder.ToString();
    }
    // Get the string of the action with last invoked trigger and last invoked output
    public string ToStringWithHistory(bool includeOutput = true)
    {
        string output = includeOutput ? lastInvokedOutput : "<none>";
        return lastInvokedTrigger + " --> " + GetType().Name + " --> " + output + " (at " + gameObject.Path() + ")";
    }
    public override string ToString()
    {
        return GetType().Name + " (at " + gameObject.Path() + ")";
    }
}
