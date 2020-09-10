using UnityEngine;
using UnityEngine.Events;

public class SetString : MonoBehaviour
{
    public Input<string> input;

    public Result<string> result;

    public UnityEvent output;

    public void Invoke()
    {
        result.value = input.value;
        output.Invoke();
    }
}
