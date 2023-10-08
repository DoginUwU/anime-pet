using Godot;

namespace GameCommon;

public enum InterpolationType {
    Linear,
    Constant
}

public class CommonInterpolation {
    public static float Lerp(float firstValue, float secondValue, float t)
    {
        return firstValue + (secondValue - firstValue) * t;
    }

    public static Vector2 Lerp(Vector2 firstVector, Vector2 secondVector, float t)
    {
        float retX = Lerp(firstVector.X, secondVector.X, t);
        float retY = Lerp(firstVector.Y, secondVector.Y, t);

        return new Vector2(retX, retY);
    }

    public static Vector2I Lerp(Vector2I firstVector, Vector2I secondVector, float t)
    {
        int retX = (int)Lerp(firstVector.X, secondVector.X, t);
        int retY = (int)Lerp(firstVector.Y, secondVector.Y, t);

        return new Vector2I(retX, retY);
    }
}