using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class AddInts : MonoBehaviour
{
    [SerializeField]
    private IntReference int1;

    [SerializeField]
    private IntReference int2; 

    [SerializeField]
    private IntVariable result;

    [SerializeField]
    private UnityEvent output;

    public void Add()
    {
        result.value = int1.value + int2.value;
        output.Invoke();
    }
}