using UnityEngine;
using System.Collections.Generic;

public class SetRotation : Action
{
    // FIELDS
    public Input<GameObject> input;
    public Input<Quaternion> newRotation;

    public OutputPackage _outputs = new OutputPackage(new string[]{ "Output" });

    // PROPERTIES
    public override TriggerPackage triggers
    {
        get
        {
            return new TriggerPackage(new Dictionary<string, Trigger>()
            {
                { "Invoke", new Trigger(Invoke) }
            });
        }
    }
    public override OutputPackage outputs
    {
        get => _outputs;
    }

    // METHODS
    public void Invoke()
    {
        input.value.transform.rotation = newRotation.value;
        Output("Output");
    }
}
