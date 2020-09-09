using UnityEngine;
using System.Collections.Generic;

public class Event : MonoBehaviour
{
    public Input<Event> reciever;
    public Input<string> methodName;

    public List<EventHook> outputs;

    public void Invoke()
    {
        EventHook r = reciever.value.outputs.Find(hook => methodName.value == hook.name.value);

        if(r != null)
        {
            r.hook.Invoke();
        }
    }
}
