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
            SetValue(value, null);
        }
    }

    // CONSTRUCTORS
    public Result() : this(default(Variable<Type>)) { }
    public Result(Variable<Type> var) : this(ResultType.Variable, var, null) { }
    public Result(Function<Variable<Type>> f) : this(ResultType.Function, null, f) { }
    public Result(Result<Type> other) : this(other.type, other.variable, other.function) { }

    protected Result(ResultType t, Variable<Type> var, Function<Variable<Type>> f)
    {
        type = t;
        variable = var;
        function = f;
    }

    // METHODS
    public void SetValue(Type val, History parent = null)
    {
        switch (type)
        {
            case ResultType.Variable:
                SetVariableValue(variable, val);
                break;
            case ResultType.Function:
                if (function)
                {
                    SetVariableValue(function.Get(parent), val);
                }
                break;
        }
    }

    // HELPERS
    private void SetVariableValue(Variable<Type> var, Type val)
    {
        if (var) var.value = val;
    }
}
