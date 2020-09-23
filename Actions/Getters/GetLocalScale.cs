using UnityEngine;
using UnityEngine.Events;

public class GetLocalScale : MonoBehaviour
{
    public Input<GameObject> input;

    public Result<Vector3> result;

    public UnityEvent output;

    public void Invoke()
    {
        result.value = input.value.transform.localScale;
        output.Invoke();
    }
}
