using UnityEngine;

public class SmoothVector2 : Smooth<Vector2>
{
    protected override Vector2 Lerp(Vector2 a, Vector2 b, float t)
    {
        return Vector2.Lerp(a, b, t);
    }
}
