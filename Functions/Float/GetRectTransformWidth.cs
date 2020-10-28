using UnityEngine;

public class GetRectTransformWidth : Function<float>
{
    public Input<GameObject> input;

    protected override float GetValue()
    {
        RectTransform rect = input.value.GetComponent<RectTransform>();

        if (rect != null)
        {
            return rect.rect.width;
        }
        else return 0;
    }
}
