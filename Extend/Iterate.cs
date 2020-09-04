using UnityEngine;

public class Iterate : MonoBehaviour
{
    // FIELDS
    // Public
    public Input<int> start;
    public Input<int> end;
    public Result<int> current;
    public ActionEvents outputs;

    // Private
    private int currentValue;
    private bool activated = false;

    // INTERFACE
    public void IterateNext()
    {
        if(!activated)
        {
            Activate();
        }

        if(currentValue == start.value)
        {
            outputs.start.Invoke();
        }

        outputs.step.Invoke();
        IncrementCurrent();

        if(currentValue == start.value)
        {
            outputs.stop.Invoke();
        }
    }
    public void IterateAllRemaining()
    {
        int remaining = end.value - currentValue;

        while(remaining > 0)
        {
            IterateNext();
            remaining--;
        }
    }
    public void IterateAll()
    {
        SetCurrent(start.value);
        IterateAllRemaining();
    }

    // HELPERS
    private void Activate()
    {
        SetCurrent(start.value);
        activated = true;
    }
    private void SetCurrent(int value)
    {
        // If the value exceeds the end value, set it back
        if(value >= end.value)
        {
            value -= end.value;
        }

        current.value = value;
        currentValue = value;
    }
    private void IncrementCurrent()
    {
        SetCurrent(currentValue + 1);
    }
}
