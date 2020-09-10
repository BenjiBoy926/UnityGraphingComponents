using UnityEngine;
using UnityEngine.Events;

public class FindGameObjectWithTag : MonoBehaviour
{
    [TagSelector]
    public string findTag;

    public Result<GameObject> firstResult;
    public Result<GameObject[]> allResults;

    public UnityEvent output;

    public void Find()
    {
        firstResult.value = GameObject.FindGameObjectWithTag(findTag);
        output.Invoke();
    }
    public void FindAll()
    {
        SetResults(GameObject.FindGameObjectsWithTag(findTag));
        output.Invoke();
    }

    private void SetResults(GameObject[] found)
    {
        allResults.value = found;

        if (found.Length > 0)
        {
            firstResult.value = found[0];
        }
        else firstResult.value = null;
    }
}
