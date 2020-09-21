﻿using UnityEngine;

public class CompareTag : MonoBehaviour
{
    [Tooltip("Reference to the event component that triggers this event")]
    public Input<GameObject> gameObjectReference;
    [TagSelector]
    [Tooltip("Check if the game object's tag is equal to this one")]
    public string tagToCheck;

    [Tooltip("Events invoked after the tag is checked")]
    public BoolEvents events;

    public void Invoke()
    {
        if (gameObjectReference.value != null)
        {
            if (gameObjectReference.value.CompareTag(tagToCheck))
            {
                events._true.Invoke();
            }
            else events._false.Invoke();
        }
    }
}