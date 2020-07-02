using UnityEngine;
using UnityEngine.Events;

public class Emitter2D : MonoBehaviour
{
    [SerializeField]
    private GameObjectReference prefab;
    [SerializeField]
    private GameObjectReference parent;
    [SerializeField]
    private Vector2Reference origin;
    [SerializeField]
    private Vector2Reference direction;
    [SerializeField]
    private FloatReference speed;

    [SerializeField]
    private GameObjectVariable clone;

    [SerializeField]
    private UnityEvent output;

    public void Do()
    {
        Transform cloneParent = parent.GetValue() != null ? parent.GetValue().transform : null;
        GameObject instance = Instantiate(prefab.GetValue(), origin.GetValue(), prefab.GetValue().transform.rotation, cloneParent);
        Rigidbody2D cloneRigidbody = instance.GetComponent<Rigidbody2D>();

        if(cloneRigidbody != null)
        {
            cloneRigidbody.velocity = direction.GetValue().normalized * speed.GetValue();

            clone?.SetValue(instance);
            output.Invoke();
        }
    }
}
