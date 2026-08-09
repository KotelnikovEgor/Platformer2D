using UnityEngine;

public class CollisionDetector
{
    private readonly BoxCollider2D _boxCollider;
    private readonly LayerMask _layer;
    private readonly float _checkDistance = 0.1f;

    private bool _isWallLeft;
    private bool _isWallRight;
    private bool _isGrounded;
    private bool _isCeiling;

    public bool IsWallLeft => _isWallLeft;

    public bool IsWallRight => _isWallRight;

    public bool IsGrounded => _isGrounded;

    public bool IsCeiling => _isCeiling;

    public CollisionDetector(BoxCollider2D collider, LayerMask layer)
    {
        _boxCollider = collider;
        _layer = layer;
    }

    public void Detect()
    {
        _isWallLeft = TryDetect(Vector2.left);
        _isWallRight = TryDetect(Vector2.right);
        _isGrounded = TryDetect(Vector2.down);
        _isCeiling = TryDetect(Vector2.up);
    }

    private bool TryDetect(Vector2 direction)
    {
        return Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0, direction, _checkDistance, _layer);
    }
}
