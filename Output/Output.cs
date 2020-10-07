[System.Serializable]
public class Output
{
    public Action action;
    public string triggerName;

    public void Invoke()
    {
        action.Trigger(triggerName);
    }
}
