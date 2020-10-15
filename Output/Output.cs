[System.Serializable]
public class Output
{
    // FIELDS
    [UnityEngine.SerializeField]
    private Input<Action> action;
    [UnityEngine.SerializeField]
    private string triggerName;

    // METHODS
    public void Invoke(Action invokingAction = null)
    {
        action.value.Trigger(triggerName, invokingAction);
    }
}
