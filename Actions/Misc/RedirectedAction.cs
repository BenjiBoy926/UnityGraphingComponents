// EXPERIMENTAL
public class RedirectedAction : Action
{
    // FIELDS
    // PUBLIC
    // inputs
    public Input<Action> redirect;

    // outputs
    public OutputSet _outputs = new OutputSet("Output");

    public override TriggerSet triggers
    {
        get
        {
            try
            {
                return new TriggerSet(redirect.value.triggers);
            }
            catch (System.Exception)
            {
                return new TriggerSet();
            }
        }
    }
}
