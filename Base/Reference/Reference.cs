using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class Reference<Type>
{
    public abstract Type GetValue();
    public abstract Variable<Type> GetReference();
}
