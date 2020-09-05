using UnityEngine;
using UnityEngine.Events;

public class Event<InputPackageType, ResultPacakgeType> : MonoBehaviour
    where InputPackageType : InputPackage 
    where ResultPacakgeType : ResultPacakge
{
    public InputPackageType inputs;
    public ResultPacakgeType results;
}
