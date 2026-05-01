using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundCheck _groundCheck;
    [SerializeField] private float _jumpForce = 350f;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _inputReader.JumpPressed += Jumping;
    }

    private void OnDisable()
    {
        _inputReader.JumpPressed -= Jumping;
    }

    private void Jumping()
    {
        if (_groundCheck.IsGrounded)
            _rigidbody.AddForce(Vector2.up * _jumpForce);
    }
}
