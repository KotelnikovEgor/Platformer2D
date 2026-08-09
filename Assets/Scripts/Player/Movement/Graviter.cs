using UnityEngine;

public class Graviter
{
    private readonly CollisionDetector _collisionDetector;
    private readonly float _fallMultiplier = 1.3f;
    private readonly float _upGravity;
    private readonly float _downGravity;

    public Graviter(CollisionDetector collisionDetector, float baseGravity)
    {
        _collisionDetector = collisionDetector;
        _upGravity = baseGravity;
        _downGravity = baseGravity * _fallMultiplier;
    }

    public float Apply(float currentVelocity)
    {
        if(currentVelocity <= 0f && _collisionDetector.IsGrounded)
            return 0;

        if (currentVelocity > 0f && _collisionDetector.IsCeiling)
            return 0;

        if (currentVelocity > 0)
            return currentVelocity + (_upGravity * Time.deltaTime);
        else
            return currentVelocity + (_downGravity * Time.deltaTime);
    }
}
