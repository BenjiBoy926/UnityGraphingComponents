using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class RandomVector2 : MonoBehaviour
{
    public Input<Vector2> min;
    public Input<Vector2> max;

    public Result<Vector2> result;

    public UnityEvent output;

    public void Invoke()
    {
        result.value = Get(min.value, max.value);
        output.Invoke();
    }

    public static Vector2 Get(Vector2 min, Vector2 max)
    {
        return new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
    }
}
