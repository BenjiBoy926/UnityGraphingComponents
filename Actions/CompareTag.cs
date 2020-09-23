﻿using UnityEngine;
using UnityEngine.Events;

public class CompareTag : MonoBehaviour
{
    [Tooltip("Reference to the event component that triggers this event")]
    public Input<GameObject> gameObjectReference;
    [TagSelector]
    [Tooltip("Check if the game object's tag is equal to this one")]
    public string tagToCheck;

    [Tooltip("Events invoked after the tag is checked")]
    public BoolEvents boolOutputs;

    public UnityEvent output;

    public void Invoke()
    {
        if (gameObjectReference.value != null)
        {
            if (gameObjectReference.value.CompareTag(tagToCheck))
            {
                boolOutputs._true.Invoke();
            }
            else boolOutputs._false.Invoke();
        }

        output.Invoke();
    }
}
