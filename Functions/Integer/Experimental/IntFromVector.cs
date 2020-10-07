using UnityEngine;
using System.Collections;

[System.Serializable]
public class IntFromVector
{
    // TYPEDEFS
    public enum VectorType
    {
        Vector2, Vector3
    }

    public enum VectorComponent
    {
        X, Y, Z
    }
    
    // FIELDS
    [SerializeField]
    private VectorType type;
    [SerializeField]
    private VectorComponent component;
    [SerializeField]
    private Input<Vector2Int> vector2;
    [SerializeField]
    private Input<Vector3Int> vector3;

    // PROPERTIES
    public int value
    {
        get
        {
            switch(type)
            {
                case VectorType.Vector2:
                    switch(component)
                    {
                        case VectorComponent.X: return vector2.value.x;
                        case VectorComponent.Y: return vector2.value.y;
                        default: return default;
                    }
                case VectorType.Vector3:
                    switch(component)
                    {
                        case VectorComponent.X: return vector3.value.x;
                        case VectorComponent.Y: return vector3.value.y;
                        case VectorComponent.Z: return vector3.value.z;
                        default: return default;
                    }
                default: return default;
            }
        }
    }
}
