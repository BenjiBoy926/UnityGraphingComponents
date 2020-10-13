using UnityEngine;

public class SetRotation : Action
{
    // FIELDS
    public Input<GameObject> input;
    public Input<Quaternion> newRotation;
    public OutputSet _outputs = new OutputSet();

    // PROPERTIES
    public override TriggerSet triggers => new TriggerSet(new Trigger(Invoke));
    protected override OutputSet outputs => _outputs;

    // METHODS
    public void Invoke()
    {
        input.value.transform.rotation = newRotation.value;
        Output();
    }
}
