[System.Serializable]
public class Output
{
    // FIELDS
    // public
    public Input<Action> action;
    public string triggerName;

    // METHODS
    public void Invoke(Action invokingAction = null)
    {
        action.value.Trigger(triggerName, invokingAction);
    }
}
