using UnityEngine;
using UnityEngine.Events;

public class ConvertVector3ToVector2 : MonoBehaviour
{
    public Input<Vector3> vector3;
    
    public Result<Vector2> vector2;
    
    public UnityEvent output;

    public void Invoke()
    {
        vector2.value = vector3.value;
        output.Invoke();
    }
}
