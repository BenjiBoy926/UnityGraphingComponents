using UnityEngine;

[System.Serializable]
public abstract class Reference<Type>
{
    // FIELDS
    [SerializeField]
    [Tooltip("Type of reference")]
    private ReferenceType type;

    [SerializeField]
    [Tooltip("Game Object used to get the attached variable")]
    private GameObject gameObject;

    [SerializeField]
    [Tooltip("Value in the reference")]
    private Type directValue;

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
                case ReferenceType.Value: return directValue;
                case ReferenceType.DropReference: return GetVariableValue(gameObject);
                case ReferenceType.TagReference:
                    gameObject = GameObject.FindGameObjectWithTag(tag);
                    
                    if(gameObject != null)
                    {
                        return GetVariableValue(gameObject);
                    }
                    else
                    {
                        Debug.LogWarning("No game object with tag " + tag + " found in scene");
                        return default;
                    }
                default: return value;
            }
        }
    }

    private Type GetVariableValue(GameObject gObject)
    {
        Variable<Type> variable = gObject.GetComponent<Variable<Type>>();

        if(variable != null)
        {
            return variable.value;
        }
        else
        {
            Debug.LogWarning("Could not find a variable on GameObject named " + gameObject.name + " and tagged " + gameObject.tag);
            return default;
        }
    }
}
