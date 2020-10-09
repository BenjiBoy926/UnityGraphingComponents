using UnityEngine;
using System.Collections;

// EXPERIMENTAL
public class RedirectedAction : Action
{
    // FIELDS
    // PUBLIC
    // inputs
    public Input<Action> redirect;

    // outputs
    public OutputPackage _outputs = new OutputPackage("Output");

    public override TriggerPackage triggers
    {
        get
        {
            //return new TriggerPackage(redirect.value.triggers);
            try
            {
                return new TriggerPackage(redirect.value.triggers);
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
                return new TriggerPackage();
            }
        }
    }

    public override OutputPackage outputs => _outputs;
}
