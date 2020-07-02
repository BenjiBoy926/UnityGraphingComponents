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

    public void Do()
    {
        result?.SetValue(newValue.GetValue());
        output.Invoke();
    }
}
