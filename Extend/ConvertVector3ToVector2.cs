using UnityEngine;
using UnityEngine.Events;

public class ConvertVector3ToVector2 : MonoBehaviour
{
    [SerializeField]
    private Vector3Reference vector3;
    [SerializeField]
    private Vector2Variable vector2;
    [SerializeField]
    private UnityEvent output;

    public void Invoke()
    {
        vector2.value = vector3.value;
        output.Invoke();
    }
}
