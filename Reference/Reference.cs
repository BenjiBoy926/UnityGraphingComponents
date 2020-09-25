using UnityEngine;

[System.Serializable]
public abstract class Reference<Type>
{
    // FIELDS
    [SerializeField]
    [Tooltip("If the reference evaluation is by value, the reference tries to get the direct value." +
        " If the evaluation is by function, the reference tries to get an action that generates the value")]
    private EvaluationType evaluationType;

    [SerializeField]
    [Tooltip("Type of reference")]
    private ReferenceType referenceType = ReferenceType.Direct;

    [SerializeField]
    [Tooltip("In the case of a redirected reference, determine" +
        "if the GameObject will be obtained through a variable" +
        "or by searching for the given tag")]
    private GameObjectReferenceType gameObjectReferenceType = GameObjectReferenceType.ByVariable;

    [SerializeField]
    [Tooltip("Type of a redirect reference, in the case of a Unity GameObject or Component." +
        "A direct redirect searches for the component on the GameObject or gets the GameObject directly," +
        "an indirect redirect searches for a variable with the component type on the GameObject")]
    private RedirectType redirectType = RedirectType.Direct;

    [SerializeField]
    [Tooltip("Depth of the redirection. " +
        "Zero means directly search the GameObject in the variable or with the tag," +
        "one means search the GameObject for a GameObject variable and search on THAT GameObject for the value," +
        "and so on")]
    private int redirectDepth = 0;

    [SerializeField]
    [Tooltip("Value in the reference")]
    private Type directValue = default;

    [SerializeField]
    [Tooltip("The action that will generate the value when invoked")]
    private Getter<Type> directAction;

    [SerializeField]
    [Tooltip("Variable used to get the value")]
    private Variable<Type> indirectValue = null;

    [SerializeField]
    [Tooltip("Variable used to get the action that generates the value when invoked")]
    private Variable<Getter<Type>> indirectAction;

    [SerializeField]
    [Tooltip("Variable with the Game Object to get the attached variable")]
    private GameObjectVariable redirectVariable = null;

    [SerializeField]
    [Tooltip("Tag used to find the game object with the attached variable")]
    [TagSelector]
    private string redirectTag = "";

    [SerializeField]
    private bool mainFoldout;
    [SerializeField]
    private bool advancedFoldout;

    // PROPERTIES
    public Type value
    {
        get
        {
            switch(referenceType)
            {
                case ReferenceType.Direct: return GetDirectValue();
                case ReferenceType.Indirect: return GetIndirectValue();
                case ReferenceType.Redirected: return GetRedirectedValue();
                default: return directValue;
            }
        }
        set
        {
            switch(referenceType)
            {
                case ReferenceType.Direct:
                case ReferenceType.Indirect:
                    if(indirectValue != null)
                    {
                        indirectValue.value = value;
                    }
                    break;
                case ReferenceType.Redirected:
                    GameObject redirectGameObject = GetRedirectGameObject();

                    if(redirectGameObject != null)
                    {
                        Variable<Type> variable = redirectGameObject.GetComponent<Variable<Type>>();

                        if(variable != null)
                        {
                            variable.value = value;
                        }
                    }
                    break;
                default: 
                    if(indirectValue != null)
                    {
                        indirectValue.value = value;
                    }
                    break;
            }
        }
    }

    private Type GetDirectValue()
    {
        if (evaluationType == EvaluationType.Value)
        {
            return directValue;
        }
        else return directAction.Get();
    }

    private Type GetIndirectValue()
    {
        if (evaluationType == EvaluationType.Value)
        {
            return indirectValue.value;
        }
        else return indirectAction.value.Get();
    }

    private Type GetRedirectedValue()
    {
        System.Type valueType = typeof(Type);
        GameObject redirectObject = GetRedirectGameObject();

        // If the redirect is indirect, or the type is not a GameObject or Component,
        // we'll get a variable with the generic type
        if (redirectType == RedirectType.Indirect ||
            evaluationType == EvaluationType.Function ||
            (!valueType.IsSameAsOrSubclassOf(typeof(GameObject)) &&
            !valueType.IsSameAsOrSubclassOf(typeof(Component))))
        {
            if (evaluationType == EvaluationType.Value)
            {
                return redirectObject.GetComponent<Variable<Type>>().value;
            }
            else return redirectObject.GetComponent<Variable<Getter<Type>>>().value.Get();
        }
        // If the redirect type is direct, and this is a GameObject,
        // return the exact gameobject
        else if (valueType.IsSameAsOrSubclassOf(typeof(GameObject)))
        {
            return (Type)(object)redirectObject;
        }
        // If the redirect type is direct, and this is a component,
        // return the exact component on the object
        else
        {
            return redirectObject.GetComponent<Type>();
        }
    }

    private GameObject GetRedirectGameObject()
    {
        GameObject redirectObject;

        // Get the GameObject to use for the redirect
        switch (gameObjectReferenceType)
        {
            case GameObjectReferenceType.ByVariable:
                redirectObject = redirectVariable.value;
                break;
            case GameObjectReferenceType.ByTag:
                redirectObject = GameObject.FindGameObjectWithTag(redirectTag);
                break;
            default:
                redirectObject = redirectVariable.value;
                break;
        }

        int i = 0;
        Variable<GameObject> currentRedirectVariable = redirectObject.GetComponent<Variable<GameObject>>();

        // Repeately set the redirect object based on the GameObject variable
        // on each GameObject in the search chain
        while(i < redirectDepth && currentRedirectVariable != null)
        {
            // Update the redirect object
            redirectObject = currentRedirectVariable.value;

            // Update loop control variables
            currentRedirectVariable = redirectObject.GetComponent<Variable<GameObject>>();
            i++;
        }

        return redirectObject;
    }
}
