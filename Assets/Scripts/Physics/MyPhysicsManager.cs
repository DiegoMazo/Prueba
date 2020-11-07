using UnityEngine;
public static class MyPhysicsManager
{
    public const float gravity = -9.8f;

    public static Vector2 AngleVelocity2Vector(ParabolicData parabolicData) 
    {
        float vx = parabolicData.initialVelocity * Mathf.Cos(parabolicData.angle * Mathf.Deg2Rad);
        float vy = parabolicData.initialVelocity * Mathf.Sin(parabolicData.angle * Mathf.Deg2Rad);
        return new Vector2(vx, vy);
    }
}
