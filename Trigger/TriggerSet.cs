using System.Collections.Generic;

public class TriggerSet
{
    // TYPEDEFS
    public struct Item
    {
        // FIELDS
        public string key;
        public Trigger value;

        // CONSTRUCTORS
        public Item(string k, Trigger v)
        {
            key = k;
            value = v;
        }
    }

    // FIELDS
    public Dictionary<string, Trigger> triggers { get; private set; }
    
    // CONSTRUCTORS
    public TriggerSet(TriggerSet other) : this(other.triggers) { }
    public TriggerSet(Dictionary<string, Trigger> t)
    {
        triggers = t;
    }
    public TriggerSet(params Item[] items)
    {
        triggers = new Dictionary<string, Trigger>();
        foreach(Item i in items)
        {
            triggers.Add(i.key, i.value);
        }
    }
    public TriggerSet(Trigger t) : this(new Item(Action.DEFAULT_TRIGGER_NAME, t)) { }
    public TriggerSet(string n, Trigger t) : this(new Item(n, t)) { }

    // METHODS
    public void Invoke(string name = Action.DEFAULT_TRIGGER_NAME)
    {
        triggers[name].Invoke();
    }

    [System.Runtime.CompilerServices.IndexerName("TriggerItem")]
    public Trigger this[string name]
    {
        get { return triggers[name]; }
    }
}
