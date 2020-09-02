using UnityEngine;
using UnityEngine.Events;

public class GetCurrentTime : MonoBehaviour
{
    [SerializeField]
    private FloatVariable floatVariable;
    [SerializeField]
    private UnityEvent output;

    public void Invoke()
    {
        floatVariable.value = Time.time;
        output.Invoke();
    }
}
