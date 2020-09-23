using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SetColorAlpha : MonoBehaviour
{
    public Input<Color> input;
    public Input<float> newAlpha;

    public Result<Color> result;

    public UnityEvent output;

    public void Invoke()
    {
        result.value = new Color(input.value.r, input.value.g, input.value.b, newAlpha.value);
        output.Invoke();
    }
}
