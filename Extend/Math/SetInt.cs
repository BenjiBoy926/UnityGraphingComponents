using UnityEngine;
using UnityEngine.Events;

public class SetInt : MonoBehaviour
{
    [SerializeField]
    private IntReference newValue;
    [SerializeField]
    private IntVariable result;

    [SerializeField]
    private UnityEvent output;

    public void Invoke()
    {
        result.value = newValue.value;
        output.Invoke();
    }
}
