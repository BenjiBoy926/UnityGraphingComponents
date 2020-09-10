using UnityEngine;
using UnityEngine.Events;

public class AddFloats : MonoBehaviour
{
    public Input<float> float1;
    public Input<float> float2;

    public Result<float> result;

    public UnityEvent output;

    public void Add()
    {
        result.value = float1.value + float2.value;
        output.Invoke();
    }
}
