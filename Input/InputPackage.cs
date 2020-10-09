using UnityEngine;
using System.Collections;

[System.Serializable]
public class InputPackage : NamedItems<BaseInput>
{
    // CONSTRUCTORS
    private InputPackage(string[] n, BaseInput[] i)
    {
        names = n;
        items = i;
    }

    // FACTORIES
    public static InputPackage Create<T1>(string name, Input<T1> input)
    {
        string[] names = new string[] { name };
        BaseInput[] inputs = new BaseInput[] { input };
        return new InputPackage(names, inputs);
    }
    public static InputPackage Create<T1, T2>(string name1, Input<T1> input1, 
        string name2, Input<T2> input2)
    {
        string[] names = new string[] { name1, name2 };
        BaseInput[] inputs = new BaseInput[] { input1, input2 };
        return new InputPackage(names, inputs);
    }
    public static InputPackage Create<T1, T2, T3>(string name1, Input<T1> input1, 
        string name2, Input<T2> input2, 
        string name3, Input<T3> input3)
    {
        string[] names = new string[] { name1, name2, name3 };
        BaseInput[] inputs = new BaseInput[] { input1, input2, input3 };
        return new InputPackage(names, inputs);
    }
    public static InputPackage Create<T1, T2, T3, T4>(string name1, Input<T1> input1, 
        string name2, Input<T2> input2, 
        string name3, Input<T3> input3,
        string name4, Input<T4> input4)
    {
        string[] names = new string[] { name1, name2, name3, name4 };
        BaseInput[] inputs = new BaseInput[] { input1, input2, input3, input4 };
        return new InputPackage(names, inputs);
    }
    public static InputPackage Create<T1, T2, T3, T4, T5>(string name1, Input<T1> input1,
        string name2, Input<T2> input2,
        string name3, Input<T3> input3,
        string name4, Input<T4> input4,
        string name5, Input<T5> input5)
    {
        string[] names = new string[] { name1, name2, name3, name4, name5 };
        BaseInput[] inputs = new BaseInput[] { input1, input2, input3, input4, input5 };
        return new InputPackage(names, inputs);
    }
}