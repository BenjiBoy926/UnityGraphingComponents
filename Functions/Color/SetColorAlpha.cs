using UnityEngine;

public class SetColorAlpha : Function<Color>
{
    public Input<Color> input;
    public Input<float> newAlpha;

    public override Color Get()
    {
        Color inputValue = input.value;
        return new Color(inputValue.r, inputValue.g, inputValue.b, newAlpha.value);
    }
}
