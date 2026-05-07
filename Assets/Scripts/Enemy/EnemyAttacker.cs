using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimation))]
public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private LayerMask layer;

    private readonly float _radius = 0.5f;
    private readonly float _rate = 1f;
    private readonly int _damage = 1;

    private bool _canAttack = true;
    private EnemyAnimation _enemyAnimation;

    private void Start()
    {
        _enemyAnimation = GetComponent<EnemyAnimation>();
    }

    private void Update()
    {
        if (!_canAttack)
            return;

        Collider2D hit = Physics2D.OverlapCircle(transform.position, _radius, layer);

        if (hit != null && hit.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_damage);
            _enemyAnimation.EnableAttackParameter();
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
