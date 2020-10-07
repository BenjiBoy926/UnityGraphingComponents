using UnityEngine;
using System.Collections;

public class FindGameObjectsWithTag : Function<GameObject[]>
{
    public Input<Tag> tagInput;

    public override GameObject[] Get()
    {
        return GameObject.FindGameObjectsWithTag(tagInput.value.value);
    }
}
