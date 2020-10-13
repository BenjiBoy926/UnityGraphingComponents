using UnityEngine;

public abstract class Interpolate<Type> : MonoBehaviour
{
    // FIELDS
    // PUBLIC
    // inputs
    public Input<Type> min;
    public Input<Type> max;
    public Input<float> time;
    public Input<AnimationCurve> function;

    // results
    public Result<Type> result;

    // outputs
    public OutputSet outputs = new OutputSet("Start", "Step", "Stop");

    // PRIVATE
    private bool active;
    private float interpolator;

    // PROPERTIES
    //public override TriggerPackage triggers => new TriggerPackage(
    //    new TriggerPackage.Item("Start", StartSmoothing), 
    //    new TriggerPackage.Item("Stop", StopSmoothing));

    public void StartSmoothing()
    {
        active = true;
        interpolator = 0;
        outputs.Invoke("Start");
    }

    public void StopSmoothing()
    {
        active = false;
        outputs.Invoke("Stop");
    }

    private void Update()
    {
        if(active)
        {
            // Update the interpolator and lerp the value and invoke output
            interpolator = Mathf.Clamp01(interpolator + (Time.deltaTime / time.value));
            result.value = Lerp(min.value, max.value, interpolator);
            outputs.Invoke("Step");

            active = interpolator < 1.0f;

            if(!active)
            {
                StopSmoothing();
            }
        }
    }

    protected abstract Type Lerp(Type a, Type b, float t);
}
