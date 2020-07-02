using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class InitializeEvents : MonoBehaviour
{
    [SerializeField]
    private UnityEvent awake;
    [SerializeField]
    private UnityEvent start;

    private void Awake()
    {
        awake.Invoke();   
    }
    private void Start()
    {
        start.Invoke();
    }
}
