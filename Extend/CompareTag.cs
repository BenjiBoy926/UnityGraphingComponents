using UnityEngine;

public class CompareTag : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference to the event component that triggers this event")]
    private GameObjectReference gameObjectReference;

    [SerializeField]
    [Tooltip("Check if the game object's tag is equal to this one")]
    private StringReference tagToCheck;

    [SerializeField]
    [Tooltip("Events invoked after the tag is checked")]
    private BoolEvents events;

    public void Compare()
    {
        if(gameObjectReference.GetValue().tag.Equals(tagToCheck.GetValue()))
        {
            events._true.Invoke();
        }
        else
        {
            events._false.Invoke();
        }
    }
}
