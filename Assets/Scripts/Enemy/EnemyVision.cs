using System;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private LayerMask layer;

    private readonly float _distance = 5f;

    private bool _isSeePlayer = false;

    public event Action Seessing;
    public event Action Unsawed;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * transform.localScale.x, _distance, layer);

        if (!_isSeePlayer && hit)
        {
            Seessing?.Invoke();
            _isSeePlayer = true;
        }
        else if (_isSeePlayer && !hit)
        {
            Unsawed?.Invoke();
            _isSeePlayer = false;
        }
    }
}
