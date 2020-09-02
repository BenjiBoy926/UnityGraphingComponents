﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class AddFloats : MonoBehaviour
{
    [SerializeField]
    private FloatReference float1;

    [SerializeField]
    private FloatReference float2;

    [SerializeField]
    private FloatVariable result;

    [SerializeField]
    private UnityEvent output;

    public void Add()
    {
        result.value = float1.value + float2.value;
        output.Invoke();
    }
}
