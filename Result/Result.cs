using UnityEngine;

[System.Serializable]
public class Result<Type>
{
    // TYPEDEFS
    public enum ResultType
    {
        Variable, Function
    }

    // FIELDS
    [SerializeField]
    [Tooltip("Result type")]
    private ResultType type;

    [SerializeField]
    [Tooltip("Variable to output the result to")]
    private Variable<Type> variable;

    [SerializeField]
    [Tooltip("Function that gets the variable to output the result to")]
    private Function<Variable<Type>> function;

    // PROPERTIES
    public Type value
    {
        set
        {
            switch(type)
            {
                case ResultType.Variable:
                    SetVariableValue(variable, value);
                    break;
                case ResultType.Function:
                    if(function)
                    {
                        SetVariableValue(function.Get(), value);
                    }
                    break;
            }
        }
    }

    // CONSTRUCTORS
    public Result(Variable<Type> var) : this(ResultType.Variable, var, null) { }
    public Result(Function<Variable<Type>> f) : this(ResultType.Function, null, f) { }
    public Result(Result<Type> other) : this(other.type, other.variable, other.function) { }

    protected Result(ResultType t, Variable<Type> var, Function<Variable<Type>> f)
    {
        type = t;
        variable = var;
        function = f;
    }

    // HELPERS
    private void SetVariableValue(Variable<Type> var, Type val)
    {
        if (var) var.value = val;
    }
}
