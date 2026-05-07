using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animation))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private float _jumpForce = 350f;

    private Rigidbody2D _rigidbody;
    private Animation _playerAnimation;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<Animation>();
        _inputReader.JumpPressed += Jump;
    }

    private void OnDestroy()
    {
        _inputReader.JumpPressed -= Jump;
    }

    private void Update()
    {
        if (_groundDetector.IsGrounded)
            _playerAnimation.DisableJumpParameter();
        else
            _playerAnimation.EnableJumpParameter();
    }

    private void Jump()
    {
        if (_groundDetector.IsGrounded)
            _rigidbody.AddForce(Vector2.up * _jumpForce);
    }
}
