public class FloatOperation : BasicGetterAction<float>
{
    public NumericOperation operation;
    public Input<float> _operator;
    public Input<float> operand;

    public override float Get()
    {
        switch(operation)
        {
            case NumericOperation.Add: return _operator.value + operand.value;
            case NumericOperation.Subtract: return _operator.value - operand.value;
            case NumericOperation.Multiply: return _operator.value * operand.value;
            case NumericOperation.Divide: return _operator.value / operand.value;
            case NumericOperation.Increment: return _operator.value + 1f;
            case NumericOperation.Decrement: return _operator.value - 1f;
            default: return _operator.value;
        }
    }
}
