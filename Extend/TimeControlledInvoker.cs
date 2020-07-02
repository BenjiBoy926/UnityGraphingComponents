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
        if (startReady.GetValue())
        {
            minTimeUntilNextInvokation = 0;
        }
        else minTimeUntilNextInvokation = time.GetValue();
    }

    public void Invoke()
    {
        if(Time.time >= minTimeUntilNextInvokation)
        {
            ready.Invoke();
            minTimeUntilNextInvokation = Time.time + time.GetValue();
        }
        else
        {
            notReady.Invoke();
        }
    }
}
