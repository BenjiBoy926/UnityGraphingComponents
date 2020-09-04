[System.Serializable]
public class Inputs<T>
{
    public Input<T> input;
}

[System.Serializable]
public struct Inputs<T1, T2>
{
    public Input<T1> input1;
    public Input<T2> input2;
}

[System.Serializable]
public struct Inputs<T1, T2, T3>
{
    public Input<T1> input1;
    public Input<T2> input2;
    public Input<T3> input3;
}

[System.Serializable]
public struct Inputs<T1, T2, T3, T4>
{
    public Input<T1> input1;
    public Input<T2> input2;
    public Input<T3> input3;
    public Input<T4> input4;
}

[System.Serializable]
public struct Inputs<T1, T2, T3, T4, T5>
{
    public Input<T1> input1;
    public Input<T2> input2;
    public Input<T3> input3;
    public Input<T4> input4;
    public Input<T5> input5;
}

