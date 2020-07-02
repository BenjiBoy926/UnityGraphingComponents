using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DebugComponent : MonoBehaviour
{
    [SerializeField]
    private List<StringOrObject> objects;

    [SerializeField]
    private UnityEvent output;

    [SerializeField]
    private System.Type type;

    public void Log()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();

        foreach(StringOrObject obj in objects)
        {
            builder.Append(obj.ToString());
        }

        Debug.Log(builder.ToString());
    }
}
