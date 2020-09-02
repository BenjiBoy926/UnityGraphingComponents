﻿using UnityEngine;
using UnityEngine.Events;

public class GetPosition : MonoBehaviour
{
    [SerializeField]
    private GameObjectReference input;
    [SerializeField]
    private Vector3Variable result;

    [SerializeField]
    private UnityEvent output;

    public void Invoke()
    {
        result.value = input.value.transform.position;
        output.Invoke();
    }
}
