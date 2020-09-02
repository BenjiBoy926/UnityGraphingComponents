using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Trigger2DEvents : MonoBehaviour
{
    [SerializeField]
    private GameObjectVariable otherGameObject;

    [SerializeField]
    private CollisionEvents events;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        otherGameObject.value = collision.gameObject;
        events.enter.Invoke();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        otherGameObject.value = collision.gameObject;
        events.stay.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        otherGameObject.value = collision.gameObject;
        events.exit.Invoke();
    }
}
