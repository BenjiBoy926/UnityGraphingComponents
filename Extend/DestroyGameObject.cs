using UnityEngine;
using UnityEngine.Events;

public class DestroyGameObject : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Game object to be destroyed")]
    private GameObjectReference objectReference;

    [SerializeField]
    [Tooltip("Amount of time it takes before the object is destoyed")]
    private FloatReference time;

    [SerializeField]
    private UnityEvent output;

    public void Destroy()
    {
        Destroy(objectReference.GetValue());
        output.Invoke();
    }

    public void DestroyWithTime()
    {
        Destroy(objectReference.GetValue(), time.GetValue());
        output.Invoke();
    }
}
