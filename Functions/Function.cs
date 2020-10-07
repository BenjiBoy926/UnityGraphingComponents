using UnityEngine;
using UnityEngine.Events;

public class Function<TResult> : MonoBehaviour
{
    public virtual TResult Get()
    {
        throw new System.NotImplementedException("Subclass of Function named " + GetType().Name + 
            " does not override base Get() method where overriding is required");
    }
}
