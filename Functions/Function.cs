using UnityEngine;

public class Function<TResult> : MonoBehaviour
{
    // Past invokation history for the function
    private History history;

    public TResult Invoke(History parent)
    {
        history = new History(parent, this);

        if(history.IsCircular())
        {
            history.LogError(new System.StackOverflowException("Self-invokation is not allowed: " + ToString()));
            return default;
        }

        try
        {
            return Get();
        }
        catch(System.Exception e)
        {
            history.LogError(e);
            return default;
        }
    }

    public virtual TResult Get()
    {
        throw new System.NotImplementedException(GetType().Name + 
            " does not override base Get() method where overriding is required");
    }

    public override string ToString()
    {
        return "Function: " + GetType() + " (at " + gameObject.Path() + ")";
    }
}
