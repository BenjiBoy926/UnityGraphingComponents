using UnityEngine;
using System.Collections.Generic;

public class Action : MonoBehaviour
{
    // PROPERTIES
    public virtual TriggerPackage triggers
    {
        get => throw new System.NotImplementedException("Subclass " + GetType().Name +
            " does not override base property \"triggers\" where overriding is required");
    }
    public virtual OutputPackage outputs
    {
        get => throw new System.NotImplementedException("Subclass " + GetType().Name +
            " does not override base property \"outputs\" where overriding is required");
    }

    // METHODS
    public void Trigger(string name)
    {
        triggers.Invoke(name);
    }
    public void Output(string name)
    {
        outputs.Invoke(name);
    }
}
