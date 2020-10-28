using UnityEngine;

public class Instantiate : Function<GameObject>
{ 
    public Input<GameObject> prefab;
    public Input<GameObject> parent;
    public Input<Vector3> localOrigin;

    protected override GameObject GetValue()
    {
        Transform cloneParent = parent.value != null ? parent.value.transform : null;
        Vector3 worldPosition = cloneParent != null ? cloneParent.position + localOrigin.value : localOrigin.value;
        return Instantiate(prefab.value, worldPosition, prefab.value.transform.rotation, cloneParent);
    }
}
