using System.Linq;
using System.Collections.Generic;
using System;

[System.Serializable]
public class OutputSet
{
    // FIELDS
    [UnityEngine.SerializeField]
    private Pair<string, OutputList>[] _outputs;

    // PROPERTIES
    public List<Pair<string, OutputList>> outputs
    {
        get
        {
            List<Pair<string, OutputList>> pairs = new List<Pair<string, OutputList>>();

            // Iterate over all unique output names
            foreach(string name in uniqueNames)
            {
                // Get all pairs with the current unique name
                Pair<string, OutputList>[] pairsWithName = Array.FindAll(_outputs, x => x.one == name);

                // Create a pair with this name and all output lists in the pairs with the given name joined together
                pairs.Add(new Pair<string, OutputList>(name, OutputList.Join(pairsWithName.Select(x => x.two).ToArray())));
            }

            return pairs;
        }
    }
    protected string[] uniqueNames
    {
        get
        {
            return _outputs.Select(x => x.one).Distinct().ToArray();
        }
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
    public void Invoke(string name = Action.DEFAULT_OUTPUT_NAME, History parent = null)
    {
        Pair<string, OutputList> pair = System.Array.Find(_outputs, x => x.one == name);
        if(pair != null)
        {
            pair.two.Invoke(parent);
        }
    }
}
