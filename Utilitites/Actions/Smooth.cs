using UnityEngine;

public abstract class Smooth<Type> : MonoBehaviour
{
    public AnimationCurve interpolationFunction;

    public Input<Type> start;
    public Input<Type> end;
    public Input<float> time;

    public Result<Type> result;

    public ActionEvents outputs;

    private bool active;
    private float interpolator;

    public void StartSmoothing()
    {
        active = true;
        interpolator = 0;
        outputs.start.Invoke();
    }

    public void StopSmoothing()
    {
        active = false;
        outputs.stop.Invoke();
    }

    private void Update()
    {
        if(active)
        {
            // Update the interpolator and lerp the value and invoke output
            interpolator = Mathf.Clamp01(interpolator + (Time.deltaTime / time.value));
            result.value = Lerp(start.value, end.value, interpolationFunction.Evaluate(interpolator));
            outputs.step.Invoke();

            active = interpolator < 1.0f;

            if(!active)
            {
                StopSmoothing();
            }
        }
    }

    protected abstract Type Lerp(Type a, Type b, float t);
}
