using UnityEngine;

public class SetColorAlpha : Function<Color>
{
    public Input<Color> input;
    public Input<float> newAlpha;

    protected override Color GetValue()
    {
        Color inputValue = input.value;
        return new Color(inputValue.r, inputValue.g, inputValue.b, newAlpha.value);
    }
}
