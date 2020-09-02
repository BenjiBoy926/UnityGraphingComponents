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

    public void Invoke()
    {
        Transform cloneParent = parent.value != null ? parent.value.transform : null;
        GameObject instance = Instantiate(prefab.value, origin.value, prefab.value.transform.rotation, cloneParent);
        Rigidbody2D cloneRigidbody = instance.GetComponent<Rigidbody2D>();

        if(cloneRigidbody != null)
        {
            cloneRigidbody.velocity = direction.value.normalized * speed.value;

            clone.value = instance;
            output.Invoke();
        }
    }
}
