using UnityEngine;
using UnityEngine.Events;

public class RandomInt : MonoBehaviour
{
    public Input<int> min;
    public Input<int> max;

    public Result<int> result;

    public UnityEvent output;

    public void Invoke()
    {
        result.value = Random.Range(min.value, max.value);
        output.Invoke();
    }
}
