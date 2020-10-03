﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetVector3Z : Function<float>
{
    public Input<Vector3> input;

    public override float Get()
    {
        return input.value.z;
    }
}
