[System.Serializable]
public class OutputPackage
{
    // FIELDS
    [UnityEngine.SerializeField]
    private OutputList[] outputs;
    [UnityEngine.SerializeField]
    private string[] outputNames;

    // CONSTRUCTORS
    public OutputPackage(string[] oN)
    {
        outputNames = oN;
    }

    // METHODS
    public void Invoke(string name)
    {
        int index = System.Array.FindIndex(outputNames, i => name == i);
        outputs[index].Invoke();
    }
}
