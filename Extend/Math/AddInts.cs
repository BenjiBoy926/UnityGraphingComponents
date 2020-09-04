using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class AddInts : MonoBehaviour
{
    public Input<int> int1;
    public Input<int> int2; 

    public Result<int> result;

    public UnityEvent output;

    public void Add()
    {
        result.value = int1.value + int2.value;
        output.Invoke();
    }
}