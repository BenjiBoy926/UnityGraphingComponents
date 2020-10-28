using UnityEngine;
using System.Linq;
using System.Collections.Generic;

[System.Serializable]
public class OutputList
{
    // FIELDS
    [SerializeField]
    private Output[] outputs;

    // CONSTRUCTORS
    public OutputList() : this(null) { }
    public OutputList(IEnumerable<Output> enumerable) : this(enumerable.ToArray()) { }
    public OutputList(Output[] o)
    {
        outputs = o;
    }

    // FACTORIES
    // Join multiple output lists into a single output list
    public static OutputList Join(params OutputList[] outputLists)
    {
        if (outputLists != null)
        {
            if (outputLists.Length >= 1)
            {
                IEnumerable<Output> outputs = outputLists[0].outputs;
                for (int i = 1; i < outputLists.Length; i++)
                {
                    outputs = outputs.Concat(outputLists[i].outputs);
                }
                return new OutputList(outputs);
            }
            else return new OutputList(new Output[0]);
        }
        else return new OutputList(new Output[0]);
        
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
