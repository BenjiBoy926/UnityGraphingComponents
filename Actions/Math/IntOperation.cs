using UnityEngine;

public class IntOperation : BasicGetterAction<int>
{
    public NumericOperation operation;
    public Input<int> _operator;
    public Input<int> operand;

    public override int Get()
    {
        switch (operation)
        {
            case NumericOperation.Add: return _operator.value + operand.value;
            case NumericOperation.Subtract: return _operator.value - operand.value;
            case NumericOperation.Multiply: return _operator.value * operand.value;
            case NumericOperation.Divide: return _operator.value / operand.value;
            case NumericOperation.Increment: return _operator.value + 1;
            case NumericOperation.Decrement: return _operator.value - 1;
            default: return _operator.value;
        }
    }
}
