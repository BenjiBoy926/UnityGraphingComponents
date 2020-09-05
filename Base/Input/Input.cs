using UnityEngine;

[System.Serializable]
public class Input<Type>
{
    // FIELDS
    [SerializeField]
    [Tooltip("Type of reference")]
    private InputType type;

    [SerializeField]
    [Tooltip("Value in the reference")]
    private Type directValue;

    [SerializeField]
    [Tooltip("Variable used to get the value")]
    private Variable<Type> directReference;

    [SerializeField]
    [Tooltip("Variable with the Game Object to get the attached variable")]
    private GameObjectVariable indirectReference;

    [SerializeField]
    [Tooltip("Tag used to find the game object with the attached variable")]
    [TagSelector]
    private string tag;

    // PROPERTIES
    public Type value
    {
        get
        {
            switch (type)
            {
                case InputType.DirectValue: return directValue;
                case InputType.DirectReference: return directReference.value;
                case InputType.IndirectReference: return GetVariableValue(indirectReference.value);
                case InputType.TagReference:
                    GameObject taggedGameObject = GameObject.FindGameObjectWithTag(tag);
                    
                    if(taggedGameObject != null)
                    {
                        return GetVariableValue(taggedGameObject);
                    }
                    else
                    {
                        Debug.LogWarning("No game object with tag " + tag + " found in scene");
                        return default;
                    }
                default: return directValue;
            }
        }
    }

    // Try to get a variable value on a particular game object
    private Type GetVariableValue(GameObject gObject)
    {
        Variable<Type> variable = gObject.GetComponent<Variable<Type>>();

        if(variable != null)
        {
            return variable.value;
        }
        else
        {
            Debug.LogWarning("Could not find a variable on GameObject named " + gObject.name + " and tagged " + gObject.tag);
            return default;
        }
    }
}
