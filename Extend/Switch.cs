using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Switch : MonoBehaviour
{
    [SerializeField]
    private IntReference startingOutputIndex;

    [SerializeField]
    private List<UnityEvent> outputs;

    private int currentOutput;

    private void Awake()
    {
        currentOutput = startingOutputIndex.GetValue() % outputs.Count;
    }

    public void Invoke()
    {
        outputs[currentOutput].Invoke();
        currentOutput = (currentOutput + 1) % outputs.Count;
    }
}
