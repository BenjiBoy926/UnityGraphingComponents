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
        result.value = Random.Range(min.value, max.value);
        output.Invoke();
    }
}
