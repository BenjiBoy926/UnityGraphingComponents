using UnityEngine;
using UnityEngine.Events;

public class FindGameObjectWithTag : Function<GameObject>
{
    public Input<Tag> tagInput;

    protected override GameObject GetValue()
    {
        return GameObject.FindGameObjectWithTag(tagInput.value.value);
    }
}
