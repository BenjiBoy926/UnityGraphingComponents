using UnityEngine;
using UnityEngine.Events;

public class GetDeltaTime : MonoBehaviour
{
    public Result<float> result;

    public UnityEvent output;

    public void Invoke()
    {
        result.value = Time.deltaTime;
        output.Invoke();
    }
}
