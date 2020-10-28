using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntToString : Function<string>
{
    public Input<int> integer;

    protected override string GetValue()
    {
        return integer.value.ToString();
    }
}
