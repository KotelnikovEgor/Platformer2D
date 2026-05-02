using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundDetector _groundCheck;
    [SerializeField] private float _jumpForce = 350f;

    private Rigidbody2D _rigidbody;

    public event Action Jumping;
    public event Action Grounded;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _inputReader.JumpPressed += Jump;
    }

    private void OnDisable()
    {
        _inputReader.JumpPressed -= Jump;
    }

    private void Update()
    {
        if (_groundCheck.IsGrounded)
            Grounded?.Invoke();
        else
            Jumping?.Invoke();
    }

    private void Jump()
    {
        if (_groundCheck.IsGrounded)
            _rigidbody.AddForce(Vector2.up * _jumpForce);
    }
}
