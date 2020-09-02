using UnityEngine;
using System.Collections;

public class CompareFloats : MonoBehaviour
{
    [SerializeField]
    [Tooltip("First integer to compare")]
    private FloatReference float1;

    [SerializeField]
    [Tooltip("Second integer to compare")]
    private FloatReference float2;

    [SerializeField]
    private CompareEvents events;

    public void Compare()
    {
        if (float1.value == float2.value)
        {
            events.equalTo.Invoke();
        }
        if (float1.value != float2.value)
        {
            events.notEqualTo.Invoke();
        }
        if (float1.value < float2.value)
        {
            events.lessThan.Invoke();
        }
        if (float1.value <= float2.value)
        {
            events.lessThanOrEqualTo.Invoke();
        }
        if (float1.value > float2.value)
        {
            events.greaterThan.Invoke();
        }
        if (float1.value >= float2.value)
        {
            events.greaterThanOrEqualTo.Invoke();
        }
    }
}
