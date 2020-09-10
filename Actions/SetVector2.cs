using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class SetVector2 : MonoBehaviour
{
    public Input<Vector2> newValue;
 
    public Result<Vector2> result;

    public UnityEvent output;

    public void Invoke()
    {
        result.value = newValue.value;
        output.Invoke();
    }
}
