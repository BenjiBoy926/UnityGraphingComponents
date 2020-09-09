using UnityEngine;

[System.Serializable]
public abstract class Reference<Type>
{
    // FIELDS
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
    private Type direct = default;

    [SerializeField]
    [Tooltip("Variable used to get the value")]
    private Variable<Type> indirect = null;

    [SerializeField]
    [Tooltip("Variable with the Game Object to get the attached variable")]
    private GameObjectVariable redirectVariable = null;

    [SerializeField]
    [Tooltip("Tag used to find the game object with the attached variable")]
    [TagSelector]
    private string redirectTag = "";

    // PROPERTIES
    public Type value
    {
        get
        {
            switch(referenceType)
            {
                case ReferenceType.Direct: return direct;
                case ReferenceType.Indirect: return indirect.value;
                case ReferenceType.Redirected: return GetRedirectedValue();
                default: return direct;
            }
        }
        set
        {
            switch(referenceType)
            {
                case ReferenceType.Direct:
                case ReferenceType.Indirect:
                    if(indirect != null)
                    {
                        indirect.value = value;
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
                    if(indirect != null)
                    {
                        indirect.value = value;
                    }
                    break;
            }
        }
    }

    private Type GetRedirectedValue()
    {
        System.Type valueType = direct.GetType();
        GameObject redirectObject = GetRedirectGameObject();

        // If the redirect is indirect, or the type is not a GameObject or Component,
        // we'll get a variable with the generic type
        if (redirectType == RedirectType.Indirect ||
            (!valueType.IsSameAsOrSubclassOf(typeof(GameObject)) &&
            !valueType.IsSameAsOrSubclassOf(typeof(Component))))
        {
            return redirectObject.GetComponent<Variable<Type>>().value;
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
        Variable<GameObject> currentRedirectVariable;

        // Repeately set the redirect object based on the GameObject variable
        // on each GameObject in the search chain
        while(i < redirectDepth && redirectObject != null)
        {
            currentRedirectVariable = redirectObject.GetComponent<Variable<GameObject>>();

            if (redirectVariable != null)
            {
                redirectObject = redirectVariable.value;
            }
            else redirectObject = null;

            i++;
        }

        return redirectObject;
    }
}
