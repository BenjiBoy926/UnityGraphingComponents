using UnityEngine;
using System.Collections.Generic;
using System.Text;

public class History
{
    // FIELDS
    private History parent;
    private object context;

    // CONSTRUCTORS
    public History(History p, object ctx)
    {
        parent = p;
        context = ctx;
    }

    // METHODS
    // List all contexts on this history and all parent histories
    public List<object> Traceback()
    {
        List<object> list = new List<object>();
        TracebackLoop(this, history => list.Add(history.context));
        return list;
    }

    // Get the traceback as a formatted multi-line string
    public string TracebackFormatted()
    {
        StringBuilder builder = new StringBuilder();
        foreach(object ctx in Traceback())
        {
            builder.Append(ctx.ToString());
            builder.Append(System.Environment.NewLine);
        }
        return builder.ToString();
    }

    // Ask the history to log the traceback of all history, and the stack trace of the provided exception
    public void LogError(System.Exception e)
    {
        Debug.LogError(
            e.GetType().Name + ": " + e.Message + System.Environment.NewLine + System.Environment.NewLine +
            "History trace:" + System.Environment.NewLine +
            TracebackFormatted() + System.Environment.NewLine +
            "Stack trace:" + System.Environment.NewLine +
            e.StackTrace);
    }

    // Return true if the context on this history is the same as any context 
    // on any other history in the chain
    public bool IsCircular()
    {
        History current = parent;
        while(current != null)
        {
            if(current.context == context)
            {
                return true;
            }
            current = current.parent;
        }
        return false;
    }

    // STATIC METHODS
    public static void TracebackLoop(History history, System.Action<History> action)
    {
        while(history != null)
        {
            action.Invoke(history);
            history = history.parent;
        }
    }
}
