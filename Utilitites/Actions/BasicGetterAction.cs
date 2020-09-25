using UnityEngine.Events;

public class BasicGetterAction<TResult> : Getter<TResult>
{
    public Result<TResult> result;

    public UnityEvent output;

    public void Invoke()
    {
        result.value = Get();
        output.Invoke();
    }
}
