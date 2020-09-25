using UnityEngine;
using UnityEngine.Events;

public class ConvertScreenToWorld : MonoBehaviour
{
    public enum ScreenToWorldConversionType
    {
        ScreenToWorld,
        WorldToScreen
    }

    public bool normalized;
    public ScreenToWorldConversionType type;

    public Input<Camera> viewport;
    public Input<Vector3> input;

    public Result<Vector3> result;

    public UnityEvent output;

    public void Invoke()
    {
        switch(type)
        {
            case ScreenToWorldConversionType.ScreenToWorld:
                if (normalized)
                {
                    result.value = viewport.value.ViewportToWorldPoint(input.value);
                }
                else result.value = viewport.value.ScreenToWorldPoint(input.value);
                break;
            case ScreenToWorldConversionType.WorldToScreen:
                if (normalized)
                {
                    result.value = viewport.value.WorldToViewportPoint(input.value);
                }
                else result.value = viewport.value.WorldToScreenPoint(input.value);
                break;
            default:
                result.value = viewport.value.ScreenToWorldPoint(input.value);
                break;
        }

        output.Invoke();
    }
}
