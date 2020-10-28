using UnityEngine;
using System.Collections;

public class FindGameObjectsWithTag : Function<GameObject[]>
{
    public Input<Tag> tagInput;

    protected override GameObject[] GetValue()
    {
        return GameObject.FindGameObjectsWithTag(tagInput.value.value);
    }
}
