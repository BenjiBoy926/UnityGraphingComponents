using UnityEngine;

public class Setter<Type> : MonoBehaviour
{
    // FIELDS
    // PUBLIC
    // inputs
    public Input<Type> input;

    // results
    public Result<Type> result;

    // outputs
    public OutputSet outputs = new OutputSet("Output");

    // PROPERTIES
    //public override TriggerSet triggers => new TriggerSet(new Trigger(Invoke));

    public void Invoke()
    {
        result.value = input.value;
        outputs.Invoke("Output");
    }
}
