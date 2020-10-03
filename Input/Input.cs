using UnityEngine;

[System.Serializable]
public class Input<Type>
{
    // TYPEDEFS
    public enum InputType
    {
        Value, Variable, Function
    }

    // FIELDS
    [SerializeField]
    [Tooltip("Input type")]
    private InputType type;

    [SerializeField]
    [Tooltip("Value of the input")]
    private Type _value;

    [SerializeField]
    [Tooltip("Variable used to get the value of the input")]
    private Variable<Type> variable;

    [SerializeField]
    [Tooltip("Function used to get the value of the input")]
    private Function<Type> function;

    // PROPERTIES
    public Type value
    {
        get
        {
            switch(type)
            {
                case InputType.Value: return _value;
                case InputType.Variable: return variable.value;
                case InputType.Function: return function.Get();
                default: return default;
            } 
        }
    }

    // CONSTRUCTORS
    public Input(Type v) : this(InputType.Value, v, null, null) { }
    public Input(Variable<Type> var) : this(InputType.Variable, default, var, null) { }
    public Input(Function<Type> f) : this(InputType.Function, default, null, f) { }
    public Input(Input<Type> other) : this(other.type, other._value, other.variable, other.function) { }

    protected Input(InputType t, Type v, Variable<Type> var, Function<Type> f)
    {
        type = t;
        _value = v;
        variable = var;
        function = f;
    }
}
