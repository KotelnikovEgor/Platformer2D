using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask layer;

    private readonly float _radius = 0.1f;

    public bool IsGrounded { get; private set; } = true;

    private void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(transform.position, _radius, layer);
    }
}
