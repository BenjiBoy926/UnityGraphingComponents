using UnityEngine;
using UnityEngine.Events;

public class RandomInt : MonoBehaviour
{
    [SerializeField]
    private IntReference min;
    [SerializeField]
    private IntReference max;

    [SerializeField]
    private IntVariable result;

    [SerializeField]
    private UnityEvent output;

    public void Invoke()
    {
        result?.SetValue(Random.Range(min.GetValue(), max.GetValue()));
        output.Invoke();
    }
}
