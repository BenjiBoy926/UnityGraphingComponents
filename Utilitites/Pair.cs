using UnityEngine;

[System.Serializable]
public class Pair<T1, T2>
{
    [SerializeField]
    private T1 _one;
    [SerializeField]
    private T2 _two;

    // PROPERTIES
    public T1 one
    {
        get => _one;
    }
    public T2 two
    {
        get => _two;
    }

    public Pair(T1 o, T2 t)
    {
        _one = o;
        _two = t;
    }
}
