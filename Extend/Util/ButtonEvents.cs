using UnityEngine.Events;
using System.Collections;

[System.Serializable]
public struct ButtonEvents
{
    public UnityEvent down;
    public UnityEvent stay;
    public UnityEvent up;
}
