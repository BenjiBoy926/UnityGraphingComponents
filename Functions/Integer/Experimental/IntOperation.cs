using UnityEngine;

[System.Serializable]
public class IntOperation
{
    // TYPEDEFS
    public enum Operation
    {
        Add, Subtract, Multiply, Divide, Mod
    }

    // FIELDS
    [SerializeField]
    private Operation operation;
    [SerializeField]
    private Input<int> _operator;
    [SerializeField]
    private Input<int> operand;

    // PROPERTIES
    public int value
    {
        get
        {
            switch(operation)
            {
                case Operation.Add: return _operator.value + operand.value;
                case Operation.Subtract: return _operator.value - operand.value;
                case Operation.Multiply: return _operator.value * operand.value;
                case Operation.Divide: return _operator.value / operand.value;
                case Operation.Mod: return _operator.value % operand.value;
                default: return default;
            }
        }
    }

    // CONSTRUCTORS
    public IntOperation(Operation op, Input<int> o1, Input<int> o2)
    {
        operation = op;
        _operator = o1;
        operand = o2;
    }
}
