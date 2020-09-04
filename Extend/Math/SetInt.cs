using UnityEngine;
using UnityEngine.Events;

public class SetInt : MonoBehaviour
{
    public Input<int> newValue;
  
    public Result<int> result;

    public UnityEvent output;

    public void Invoke()
    {
        result.value = newValue.value;
        output.Invoke();
    }
}
