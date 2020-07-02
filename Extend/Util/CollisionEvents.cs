using UnityEngine.Events;
using System.Collections;

[System.Serializable]
public struct CollisionEvents
{
    public UnityEvent enter;
    public UnityEvent stay;
    public UnityEvent exit;
}
