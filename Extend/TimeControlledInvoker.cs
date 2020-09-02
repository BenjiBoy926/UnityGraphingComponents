using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class TimeControlledInvoker : MonoBehaviour
{
    [SerializeField]
    private FloatReference time;    // Minimum time between invokations
    [SerializeField]
    private BoolReference startReady;

    [SerializeField]
    private UnityEvent ready;
    [SerializeField]
    private UnityEvent notReady;

    private float minTimeUntilNextInvokation;

    private void Start()
    {
        if (startReady.value)
        {
            minTimeUntilNextInvokation = 0;
        }
        else minTimeUntilNextInvokation = time.value;
    }

    public void Invoke()
    {
        if(Time.time >= minTimeUntilNextInvokation)
        {
            ready.Invoke();
            minTimeUntilNextInvokation = Time.time + time.value;
        }
        else
        {
            notReady.Invoke();
        }
    }
}
