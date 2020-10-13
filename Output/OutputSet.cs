[System.Serializable]
public class OutputSet : NamedItems<OutputList>
{
    // CONSTRUCTORS
    public OutputSet(params string[] n)
    {
        names = n;
    }
    public OutputSet() : this(Action.DEFAULT_OUTPUT_NAME) { }

    // METHODS
    public void Invoke(string name = Action.DEFAULT_OUTPUT_NAME, Action invokingAction = null)
    {
        OutputList outputsList = GetItem(name);
        outputsList.Invoke(invokingAction);
    }
}
