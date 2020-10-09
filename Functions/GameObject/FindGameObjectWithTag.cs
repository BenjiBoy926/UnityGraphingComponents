using UnityEngine;
using UnityEngine.Events;

public class FindGameObjectWithTag : Function<GameObject>
{
    public Input<Tag> tagInput;

    public override GameObject Get()
    {
        if(GameObject.FindGameObjectWithTag(tagInput.value.value) == null)
        {
            Debug.Log("Could not find game object with tag " + tagInput.value.value);
        }

        return GameObject.FindGameObjectWithTag(tagInput.value.value);
    }
}
