using UnityEngine;

[System.Serializable]
public class Result<Type>
{
    // FIELDS
    [SerializeField]
    [Tooltip("Type of reference to output the result to")]
    private ResultType type;

    [SerializeField]
    [Tooltip("Variable to output to")]
    private Variable<Type> directReference;

    [SerializeField]
    [Tooltip("Reference to a game object with a variable to output to")]
    private GameObjectVariable indirectReference;

    [SerializeField]
    [TagSelector]
    [Tooltip("Tag of the game object with the variable to output to")]
    private string tag;

    public Type value
    {
        set
        {
            switch(type)
            {
                case ResultType.DirectReference:
                    if(directReference != null)
                    {
                        directReference.value = value;
                    }
                    break;

                case ResultType.IndirectReference:
                    if(indirectReference != null)
                    {
                        SetVariableValue(indirectReference.value, value);
                    }
                    break;

                case ResultType.TagReference:
                    GameObject taggedGameObject = GameObject.FindGameObjectWithTag(tag);

                    if(taggedGameObject != null)
                    {
                        SetVariableValue(taggedGameObject, value);
                    }
                    break;

                default:
                    if (directReference != null)
                    {
                        directReference.value = value;
                    }
                    break;
            }
        }
    }

    private void SetVariableValue(GameObject gameObject, Type value)
    {
        if(gameObject != null)
        {
            Variable<Type> variable = gameObject.GetComponent<Variable<Type>>();

            if (variable != null)
            {
                variable.value = value;
            }
        }
    }
}
