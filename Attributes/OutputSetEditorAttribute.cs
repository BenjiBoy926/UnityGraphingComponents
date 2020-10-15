using UnityEngine;
using System.Collections;

// TYPEDEFS
public enum OutputSetEditorType
{
    Exposed, Restricted
}

public class OutputSetEditorAttribute : PropertyAttribute
{
    // PROPERTIES
    public OutputSetEditorType type { get; private set; }
    public string[] names { get; private set; }

    // CONSTRUCTORS
    public OutputSetEditorAttribute(params string[] n) : this(OutputSetEditorType.Restricted, n) { }
    public OutputSetEditorAttribute(OutputSetEditorType t = OutputSetEditorType.Restricted) : this(t, Action.DEFAULT_OUTPUT_NAME) { }
    public OutputSetEditorAttribute(OutputSetEditorType t = OutputSetEditorType.Restricted, params string[] n)
    {
        type = t;
        names = n;
    }

    public static OutputSetEditorAttribute DefaultRestricted()
    {
        return new OutputSetEditorAttribute(OutputSetEditorType.Restricted, Action.DEFAULT_OUTPUT_NAME);
    }
}
