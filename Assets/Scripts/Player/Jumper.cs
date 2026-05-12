using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerAnimator))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private float _jumpForce = 350f;

    private Rigidbody2D _rigidbody;
    private PlayerAnimator _playerAnimator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _inputReader.JumpPressed += Jump;
    }

    private void OnDestroy()
    {
        _inputReader.JumpPressed -= Jump;
    }

    private void Update()
    {
        if (_groundDetector.IsGrounded)
            _playerAnimator.DisableJumpParameter();
        else
            _playerAnimator.EnableJumpParameter();
    }

    private void Jump()
    {
        if (_groundDetector.IsGrounded)
            _rigidbody.AddForce(Vector2.up * _jumpForce);
    }
}
