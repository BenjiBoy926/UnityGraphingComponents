using UnityEngine;
using UnityEngine.Events;

public class EventFolder : MonoBehaviour
{
    [SerializeField]
    private UnityEvent input;
    [SerializeField]
    private UnityEvent output;

    public void InvokeInput()
    {
        input.Invoke();
    }

    public void InvokeOutput()
    {
        output.Invoke();
    }
}
