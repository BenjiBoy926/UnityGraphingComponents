[System.Serializable]
public class OutputSet
{
    // FIELDS
    [UnityEngine.SerializeField]
    private Pair<string, OutputList>[] _outputs;

    // PROPERTIES
    public Pair<string, OutputList>[] outputs
    {
        get => _outputs;
    }

    // CONSTRUCTORS
    public OutputSet(params string[] names)
    {
        _outputs = new Pair<string, OutputList>[names.Length];
        for(int i = 0; i < names.Length; i++)
        {
            _outputs[i] = new Pair<string, OutputList>(names[i], new OutputList());
        }
    }
    public OutputSet() : this(Action.DEFAULT_OUTPUT_NAME) { }

    // METHODS
    public void Invoke(string name = Action.DEFAULT_OUTPUT_NAME, Action invokingAction = null)
    {
        Pair<string, OutputList> pair = System.Array.Find(_outputs, x => x.one == name);
        if(pair != null)
        {
            pair.two.Invoke(invokingAction);
        }
    }
}
