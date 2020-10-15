using UnityEngine;

public class Function<TResult> : MonoBehaviour
{
    public virtual TResult Get()
    {
        throw new System.NotImplementedException(GetType().Name + 
            " does not override base Get() method where overriding is required");
    }
}
