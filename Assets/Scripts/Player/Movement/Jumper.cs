public class Jumper
{
    private readonly IJumpProvider _jumpProvider;
    private readonly CollisionDetector _collisionDetector;
    private readonly float _force;

    public Jumper(IJumpProvider jumpProvider, CollisionDetector collisionDetector, float force)
    {
        _jumpProvider = jumpProvider;
        _collisionDetector = collisionDetector;
        _force = force;
    }

    public float GetVelocityY(float currentVelocity)
    {
        if (_jumpProvider.IsJumpPressed && _collisionDetector.IsGrounded)
            return _force;

        return currentVelocity;
    }
}
