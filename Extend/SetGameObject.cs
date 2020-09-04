using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class SetGameObject : MonoBehaviour
{
    public Input<GameObject> newValue;
    public Result<GameObject> result;

    public UnityEvent output;

    public void Do()
    {
        result.value = newValue.value;
        output.Invoke();
    }
}
