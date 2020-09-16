using UnityEngine;
using UnityEngine.Events;

public class BoolOperation : MonoBehaviour
{
    public BoolOperator type;

    public Input<bool> input1;
    public Input<bool> input2;

    public Result<bool> result;

    public UnityEvent output;

    public void Invoke()
    {
        switch(type)
        {
            case BoolOperator.And:
                result.value = input1.value && input2.value;
                break;
            case BoolOperator.Or:
                result.value = input1.value || input2.value;
                break;
            case BoolOperator.Not:
                result.value = !input1.value;
                break;
            default: result.value = input1.value; break;
        }

        output.Invoke();
    }
}
