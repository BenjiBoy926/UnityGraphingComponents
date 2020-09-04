using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class SetFloat : MonoBehaviour
{
    public Input<float> newValue;
    
    public Result<float> result;

    public UnityEvent output;

    public void Invoke()
    {
        result.value = newValue.value;
        output.Invoke();
    }
}
