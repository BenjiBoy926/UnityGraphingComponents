using UnityEngine;

public class SmoothVector3 : Smooth<Vector3>
{
    protected override Vector3 Lerp(Vector3 a, Vector3 b, float t)
    {
        return Vector3.Lerp(a, b, t);
    }
}
