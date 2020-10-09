using UnityEngine;
using System.Collections.Generic;

public class SetRotation : Action
{
    // FIELDS
    public Input<GameObject> input;
    public Input<Quaternion> newRotation;
    public OutputPackage _outputs = new OutputPackage("Output");

    // PROPERTIES
    public override TriggerPackage triggers => new TriggerPackage(new TriggerPackage.Item("Invoke", Invoke));
    public override OutputPackage outputs => _outputs;

    // METHODS
    public void Invoke()
    {
        input.value.transform.rotation = newRotation.value;
        _outputs.Invoke("Output");
    }
}
