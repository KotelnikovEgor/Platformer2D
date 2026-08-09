using UnityEngine;

public class PlayerMovementInitializer : MonoBehaviour 
{
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpTime;

    public PlayerMovement Create(Rigidbody2D rigidbody, Transform transform, IDirectionProvider directionProvider, IJumpProvider jumpProvider, CollisionDetector collisionDetector)
    {
        float gravity = -(2f * _jumpHeight) / Mathf.Pow(_jumpTime, 2f);
        float jumpForce = Mathf.Abs(gravity) * _jumpTime;

        Runner runner = new(directionProvider, collisionDetector, _runSpeed);
        Fliper fliper = new(transform);
        Jumper jumper = new(jumpProvider, collisionDetector, jumpForce);
        Graviter graviter = new(collisionDetector, gravity);

        return new(rigidbody, runner, jumper, fliper, graviter);
    }
}
