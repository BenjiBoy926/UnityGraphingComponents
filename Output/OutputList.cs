using UnityEngine;

[System.Serializable]
public class OutputList
{
    // FIELDS
    [SerializeField]
    private Output[] outputs;

    // CONSTRUCTORS
    public OutputList() : this(null) { }
    public OutputList(Output[] o)
    {
        outputs = o;
    }

    // METHODS
    public void Invoke(History parent = null)
    {
        foreach(Output o in outputs)
        {
            o.Invoke(parent);
        }
    }
}
