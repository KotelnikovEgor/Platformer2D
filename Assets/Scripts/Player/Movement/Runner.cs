public class Runner
{
    private readonly IDirectionProvider _directionProvider;
    private readonly CollisionDetector _collisionDetector;
    private readonly float _speed;

    public Runner(IDirectionProvider directionProvider, CollisionDetector collisionDetector, float speed)
    {
        _directionProvider = directionProvider;
        _collisionDetector = collisionDetector;
        _speed = speed;
    }

    public float GetVelocityX()
    {
        if (_directionProvider.Direction > 0 && _collisionDetector.IsWallRight)
            return 0f;

        if (_directionProvider.Direction < 0 && _collisionDetector.IsWallLeft)
            return 0f;

        return _directionProvider.Direction * _speed;
    }
}
