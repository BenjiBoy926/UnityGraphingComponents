using UnityEngine;
using UnityEngine.Events;

public abstract class Variable<Type> : MonoBehaviour
{
    // VARIABLES
    protected Type value;

    // FUNCTIONS

    // Get/set the current value of the variable component
    public Type GetValue()
    {
        return value;
    }
    public void SetValue(Type newValue)
    {
        value = newValue;
        GetValueChangedEvent().Invoke();
    }

    // Get the name.  Get the default value.  Get the value changed event
    // Abstract because each subclass needs to expose these in Unity's editor
    public abstract string GetName();
    public abstract Type GetDefaultValue();
    public abstract UnityEvent GetValueChangedEvent();

    public void LogValue()
    {
        Debug.Log(ToString());
    }

    public override string ToString()
    {
        return GetName() + "{" + value.ToString() + "}";
    }
}
