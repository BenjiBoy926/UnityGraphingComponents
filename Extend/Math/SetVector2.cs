using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class SetVector2 : MonoBehaviour
{
    [SerializeField]
    private Vector2Reference newValue;
    [SerializeField]
    private Vector2Variable result;

    [SerializeField]
    private UnityEvent output;

    public void Invoke()
    {
        result.value = newValue.value;
        output.Invoke();
    }
}
