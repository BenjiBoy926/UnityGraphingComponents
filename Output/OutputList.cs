using UnityEngine;

[System.Serializable]
public class OutputList
{
    // FIELDS
    [SerializeField]
    private Output[] outputs;

    // CONSTRUCTORS
    public OutputList(Output[] o)
    {
        outputs = o;
    }

    // METHODS
    public void Invoke()
    {
        foreach(Output o in outputs)
        {
            o.Invoke();
        }
    }
}
