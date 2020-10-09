[System.Serializable]
public class OutputPackage : NamedItems<OutputList>
{
    // CONSTRUCTORS
    public OutputPackage(params string[] n)
    {
        names = n;
    }

    // METHODS
    public void Invoke(string name)
    {
        OutputList outputs = GetItem(name);
        outputs.Invoke();
    }
}
