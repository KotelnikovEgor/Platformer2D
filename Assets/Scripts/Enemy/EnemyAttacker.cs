using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private LayerMask layer;

    private readonly float _radius = 0.5f;
    private readonly float _rate = 1f;
    private readonly int _damage = 1;

    private bool _canAttack = true;

    private void Update()
    {
        if (!_canAttack)
            return;

        Collider2D hit = Physics2D.OverlapCircle(transform.position, _radius, layer);

        if (hit != null && hit.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_rate);
        _canAttack = true;
    }
}
