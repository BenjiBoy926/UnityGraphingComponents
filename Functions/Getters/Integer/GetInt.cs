using UnityEngine;
using System.Collections.Generic;

public class GetInt : Function<int>
{
    [SerializeField]
    private GetIntFunction type;

    [SerializeField]
    private IntOperation operation;
    [SerializeField]
    private IntConversion conversion;
    [SerializeField]
    private IntFunction function;
}

public enum GetIntFunction
{
    Operate,
    Convert,
    Function
}

