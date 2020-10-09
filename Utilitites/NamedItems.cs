using UnityEngine;

[System.Serializable]
public class NamedItems<Type>
{
    // FIELDS
    [SerializeField]
    protected Type[] items;
    [SerializeField]
    protected string[] names;

    // METHODS
    public Type GetItem(string name)
    {
        int index = System.Array.FindIndex(names, x => name == x);
        return items[index];
    }
}
