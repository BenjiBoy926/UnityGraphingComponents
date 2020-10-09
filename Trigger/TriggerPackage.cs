using System.Collections.Generic;

public class TriggerPackage
{
    // TYPEDEFS
    public struct Item
    {
        // FIELDS
        public string key;
        public Trigger value;

        // CONSTRUCTORS
        public Item(string k, System.Action v)
        {
            key = k;
            value = new Trigger(v);
        }
    }

    // FIELDS
    public Dictionary<string, Trigger> triggers { get; private set; }
    
    // CONSTRUCTORS
    public TriggerPackage(TriggerPackage other) : this(other.triggers) { }
    public TriggerPackage(Dictionary<string, Trigger> t)
    {
        triggers = t;
    }
    public TriggerPackage(params Item[] items)
    {
        triggers = new Dictionary<string, Trigger>();
        foreach(Item i in items)
        {
            triggers.Add(i.key, i.value);
        }
    }
    public TriggerPackage() : this(new Dictionary<string, Trigger>()) { }

    // METHODS
    public void Invoke(string name)
    {
        triggers[name].Invoke();
    }
}
