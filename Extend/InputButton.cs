using UnityEngine;
using UnityEngine.Events;

public class InputButton : MonoBehaviour
{
    [SerializeField]
    private StringReference inputName;

    [SerializeField]
    private ButtonEvents events;

    private void Update()
    {
        if(Input.GetButtonDown(inputName.value))
        {
            events.down.Invoke();
        }
        if(Input.GetButton(inputName.value))
        {
            events.stay.Invoke();
        }
        if(Input.GetButtonUp(inputName.value))
        {
            events.up.Invoke();
        }
    }
}
