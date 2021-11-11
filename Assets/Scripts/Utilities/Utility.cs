using UnityEngine;
using System.Collections;

public class Utility
{
    public static Quaternion ShortestRotation(Quaternion a, Quaternion b) {
        if (Quaternion.Dot(a, b) < 0)
        {
            return a * Quaternion.Inverse(Multiply(b, -1));
        }
        else 
        {
            return a * Quaternion.Inverse(b);
        }
    }

    public static Quaternion Multiply(Quaternion input, float scalar) {
        return new Quaternion(input.x * scalar, input.y * scalar, input.z * scalar, input.w * scalar);
    }

    public static float AccelerationFromDot(float _dotProduct)
    {
        return Mathf.Clamp(1 - _dotProduct, 1, 2);
    }
}
