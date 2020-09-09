using UnityEngine;
using UnityEngine.Events;

public class FindGameObject : MonoBehaviour
{
    [TagSelector]
    public string findTag;
    public Input<string> findName;

    public Result<GameObject> firstResult;
    public Result<GameObject[]> allResults;

    public UnityEvent output;

    public void FindFirst()
    {
        firstResult.value = GameObject.FindGameObjectWithTag(findTag);
        output.Invoke();
    }
    public void FindAll()
    {
        SetResults(GameObject.FindGameObjectsWithTag(findTag));
        output.Invoke();
    }
    public void FindByName()
    {
        firstResult.value = GameObject.Find(findName.value);
        output.Invoke();
    }

    private void SetResults(GameObject[] found)
    {
        allResults.value = found;

        if (found != null)
        {
            firstResult.value = found[0];
        }
        else firstResult.value = null;
    }
}
