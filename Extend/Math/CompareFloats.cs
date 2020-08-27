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
        if (float1.GetValue() == float2.GetValue())
        {
            events.equalTo.Invoke();
        }
        if (float1.GetValue() != float2.GetValue())
        {
            events.notEqualTo.Invoke();
        }
        if (float1.GetValue() < float2.GetValue())
        {
            events.lessThan.Invoke();
        }
        if (float1.GetValue() <= float2.GetValue())
        {
            events.lessThanOrEqualTo.Invoke();
        }
        if (float1.GetValue() > float2.GetValue())
        {
            events.greaterThan.Invoke();
        }
        if (float1.GetValue() >= float2.GetValue())
        {
            events.greaterThanOrEqualTo.Invoke();
        }
    }
}
