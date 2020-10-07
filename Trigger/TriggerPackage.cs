using System.Collections.Generic;

public class TriggerPackage
{
    // FIELDS
    public Dictionary<string, Trigger> triggers { get; private set; }
    
    // CONSTRUCTORS
    public TriggerPackage(Dictionary<string, Trigger> t)
    {
        triggers = t;
    }

    // METHODS
    public void Invoke(string name)
    {
        triggers[name].Invoke();
    }
}
