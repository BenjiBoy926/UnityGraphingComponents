[System.Serializable]
public class NamedItem<Type>
{
    // FIELDS
    public string name;
    public Type item;

    // CONSTRUCTORS
    public NamedItem(string n) : this(n, default) { }
    public NamedItem(string n, Type i)
    {
        name = n;
        item = i;
    }
}
