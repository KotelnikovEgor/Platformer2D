using UnityEngine;

public class PlayerMovement
{
    private readonly Rigidbody2D _rigidbody;
    private readonly Runner _runner;
    private readonly Jumper _jumper;
    private readonly Fliper _fliper;
    private readonly Graviter _graviter;
    private Vector2 _velocity;

    public Vector2 Velocity => _velocity;

    public PlayerMovement(Rigidbody2D rigidbody, Runner runner, Jumper jumper, Fliper fliper, Graviter graviter)
    {
        _rigidbody = rigidbody;
        _runner = runner;
        _jumper = jumper;
        _fliper = fliper;
        _graviter = graviter;
    }

    public void UpdateVelocity()
    {
        _velocity.x = _runner.GetVelocityX();
        _fliper.Flip(_velocity.x);
        _velocity.y = _jumper.GetVelocityY(_velocity.y);
        _velocity.y = _graviter.Apply(_velocity.y);
    }

    public void ApplyPhysics()
    {
        _rigidbody.linearVelocity = _velocity;
    }
}
