using UnityEngine;
using UnityEngine.Events;

public class MakeVector2Int : MonoBehaviour
{
    public Input<int> x;
    public Input<int> y;

    public Result<Vector2Int> result;

    public UnityEvent output;

    public void Invoke()
    {
        result.value = new Vector2Int(x.value, y.value);
        output.Invoke();
    }
}
