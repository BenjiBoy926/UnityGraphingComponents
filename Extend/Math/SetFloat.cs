using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class SetFloat : MonoBehaviour
{
    [SerializeField]
    private FloatReference newValue;
    [SerializeField]
    private FloatVariable result;

    [SerializeField]
    private UnityEvent output;

    public void Invoke()
    {
        result.value = newValue.value;
        output.Invoke();
    }
}
