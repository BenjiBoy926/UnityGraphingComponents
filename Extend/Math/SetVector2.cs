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

    public void Do()
    {
        result?.SetValue(newValue.GetValue());
        output.Invoke();
    }
}
