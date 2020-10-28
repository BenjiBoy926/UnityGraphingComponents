using UnityEngine;

public class Function<TResult> : MonoBehaviour
{
    // Past invokation history for the function
    protected History history;

    public TResult Get(History parent = null)
    {
        history = new History(parent, this);

        if(history.IsCircular())
        {
            history.LogError(new System.StackOverflowException("Self-invokation is not allowed: " + ToString()));
            return default;
        }

        try
        {
            return GetValue();
        }
        catch(System.Exception e)
        {
            history.LogError(e);
            return default;
        }
    }
    protected virtual TResult GetValue()
    {
        throw new System.NotImplementedException(GetType().Name + 
            " does not override base Get() method where overriding is required");
    }
    public override string ToString()
    {
        return "Function: " + GetType() + " (at " + gameObject.Path() + ")";
    }
}
