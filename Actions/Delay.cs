using UnityEngine;
using UnityEngine.Events;

public class Delay : MonoBehaviour
{
    public Input<float> delay;

    public UnityEvent awake;
    public UnityEvent output;

    public void Invoke()
    {
        awake.Invoke();

        CancelInvoke();
        Invoke("DelayedInvoke", delay.value);
    }

    public void InvokeImmediately()
    {
        awake.Invoke();

        CancelInvoke();
        DelayedInvoke();
    }

    private void DelayedInvoke()
    {
        output.Invoke();
    }
}
