using UnityEngine;
using UnityEngine.Events;

public class Instantiate : MonoBehaviour
{ 
    public Input<GameObject> prefab;
    public Input<GameObject> parent;
    public Input<Vector3> localOrigin;

    public Result<GameObject> clone;

    public UnityEvent output;

    public void Invoke()
    {
        Transform cloneParent = parent.value != null ? parent.value.transform : null;
        Vector3 worldPosition = cloneParent != null ? cloneParent.position + localOrigin.value : localOrigin.value;
        GameObject instance = Instantiate(prefab.value, worldPosition, prefab.value.transform.rotation, cloneParent);

        clone.value = instance;
        output.Invoke();
    }
}
