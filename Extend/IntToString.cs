using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntToString : MonoBehaviour
{
    public Input<int> integer;

    public Result<string> result;

    public UnityEvent output;

    public void Invoke()
    {
        result.value = integer.value.ToString();
        output.Invoke();
    }
}
