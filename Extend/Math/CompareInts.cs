using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class CompareInts : MonoBehaviour
{
    [SerializeField]
    [Tooltip("First integer to compare")]
    private IntReference integer1;

    [SerializeField]
    [Tooltip("Second integer to compare")]
    private IntReference integer2;

    [SerializeField]
    private CompareEvents events;

    public void Compare()
    {
        if(integer1.value == integer2.value)
        {
            events.equalTo.Invoke();
        }
        if (integer1.value != integer2.value)
        {
            events.notEqualTo.Invoke();
        }
        if (integer1.value < integer2.value)
        {
            events.lessThan.Invoke();
        }
        if (integer1.value <= integer2.value)
        {
            events.lessThanOrEqualTo.Invoke();
        }
        if (integer1.value > integer2.value)
        {
            events.greaterThan.Invoke();
        }
        if (integer1.value >= integer2.value)
        {
            events.greaterThanOrEqualTo.Invoke();
        }
    }
}
