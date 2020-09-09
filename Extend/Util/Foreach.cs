using UnityEngine;

public class Foreach<Type> : MonoBehaviour
{
    // FIELDS
    // public
    public Input<Type[]> items;

    public Result<Type> currentValue;
    public Result<int> currentIndex;

    public ActionEvents outputs;

    public void Invoke()
    {
        outputs.start.Invoke();

        for(int i = 0; i < items.value.Length; i++)
        {
            currentValue.value = items.value[i];
            currentIndex.value = i;
            outputs.step.Invoke();
        }

        outputs.stop.Invoke();
    }
}
