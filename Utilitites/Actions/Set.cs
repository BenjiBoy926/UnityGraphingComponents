﻿using UnityEngine;
using UnityEngine.Events;

public class Set<Type> : MonoBehaviour
{
    public Input<Type> input;

    public Result<Type> result;

    public UnityEvent output;

    public void Invoke()
    {
        result.value = input.value;
        output.Invoke();
    }
}
