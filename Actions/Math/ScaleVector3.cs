using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class ScaleVector3 : MonoBehaviour
{
    public Input<Vector3> input;
    public Input<float> scalar;

    public Result<Vector3> result;

    public UnityEvent output;

    public void Invoke()
    {
        result.value = input.value * scalar.value;
        output.Invoke();
    }
}
