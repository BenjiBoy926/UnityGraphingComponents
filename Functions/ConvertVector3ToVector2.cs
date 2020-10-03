﻿using UnityEngine;
using UnityEngine.Events;

public class ConvertVector3ToVector2 : Function<Vector2>
{
    public Input<Vector3> input;
    
    public override Vector2 Get()
    {
        return input.value;
    }
}
