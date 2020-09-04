using UnityEngine;
using UnityEngine.Events;

public class GetCurrentTime : MonoBehaviour
{
    public Result<float> floatVariable;
    
    public UnityEvent output;

    public void Invoke()
    {
        floatVariable.value = Time.time;
        output.Invoke();
    }
}
