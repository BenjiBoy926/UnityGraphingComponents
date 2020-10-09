﻿using System.Collections.Generic;
using UnityEngine;

public class EventReceiver : Action
{
    public List<EventHook> hooks;

    public void Invoke(string hookName)
    {
        EventHook id = hooks.Find(x => x.name == hookName);

        if(id != null)
        {
            id.hook.Invoke();
        }
    }
}
