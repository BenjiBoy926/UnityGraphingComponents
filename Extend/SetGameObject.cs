using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class SetGameObject : MonoBehaviour
{
    [SerializeField]
    private GameObjectReference newValue;
    [SerializeField]
    private GameObjectVariable result;

    [SerializeField]
    private UnityEvent output;

    public void Do()
    {
        result.value = newValue.value;
        output.Invoke();
    }
}
