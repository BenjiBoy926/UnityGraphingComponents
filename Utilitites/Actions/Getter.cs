using UnityEngine;
using UnityEngine.Events;

public class Getter<TResult> : MonoBehaviour
{
    public virtual TResult Get()
    {
        throw new System.NotImplementedException("Get() cannot be called on the base class Getter<" +
            typeof(TResult).Name + ">. Does the child class override the method?");
    }
}
