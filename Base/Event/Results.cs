[System.Serializable]
public struct Results<T>
{
    public Variable<T> result;
}

[System.Serializable]
public struct Results<T1, T2>
{
    public Variable<T1> result1;
    public Variable<T2> result2;
}

[System.Serializable]
public struct Results<T1, T2, T3>
{
    public Variable<T1> result1;
    public Variable<T2> result2;
    public Variable<T3> result3;
}

[System.Serializable]
public struct Results<T1, T2, T3, T4>
{
    public Variable<T1> result1;
    public Variable<T2> result2;
    public Variable<T3> result3;
    public Variable<T4> result4;
}

[System.Serializable]
public struct Results<T1, T2, T3, T4, T5>
{
    public Variable<T1> result1;
    public Variable<T2> result2;
    public Variable<T3> result3;
    public Variable<T4> result4;
    public Variable<T5> result5;
}

