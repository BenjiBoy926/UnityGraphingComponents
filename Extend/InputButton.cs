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
        if(Input.GetButtonDown(inputName.GetValue()))
        {
            events.down.Invoke();
        }
        if(Input.GetButton(inputName.GetValue()))
        {
            events.stay.Invoke();
        }
        if(Input.GetButtonUp(inputName.GetValue()))
        {
            events.up.Invoke();
        }
    }
}
