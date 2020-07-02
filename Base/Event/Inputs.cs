[System.Serializable]
public class Inputs<T>
{
    public Reference<T> input;
}

[System.Serializable]
public struct Inputs<T1, T2>
{
    public Reference<T1> input1;
    public Reference<T2> input2;
}

[System.Serializable]
public struct Inputs<T1, T2, T3>
{
    public Reference<T1> input1;
    public Reference<T2> input2;
    public Reference<T3> input3;
}

[System.Serializable]
public struct Inputs<T1, T2, T3, T4>
{
    public Reference<T1> input1;
    public Reference<T2> input2;
    public Reference<T3> input3;
    public Reference<T4> input4;
}

[System.Serializable]
public struct Inputs<T1, T2, T3, T4, T5>
{
    public Reference<T1> input1;
    public Reference<T2> input2;
    public Reference<T3> input3;
    public Reference<T4> input4;
    public Reference<T5> input5;
}

