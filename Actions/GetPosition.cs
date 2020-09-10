using UnityEngine;
using UnityEngine.Events;

public class GetPosition : MonoBehaviour
{
    public Input<GameObject> input;
    
    public Result<Vector3> result;

    public UnityEvent output;

    public void Invoke()
    {
        if(input.value == null)
        {
            Debug.Log("Input value is null!");
        }

        result.value = input.value.transform.position;
        output.Invoke();
    }
}
