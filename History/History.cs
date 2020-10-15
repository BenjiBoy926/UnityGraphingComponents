using UnityEngine;
using System.Collections;

public class History : MonoBehaviour
{
    // Reference to the most recent history object that invoked this history object
    private History lastInvoker;

    public void Invoke(History invoker)
    {
        lastInvoker = invoker;
    }
}
