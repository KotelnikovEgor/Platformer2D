using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private LayerMask _layer;

    private readonly float _radius = 0.6f;
    private readonly float _rate = 1f;
    private readonly int _damage = 1;

    private bool _canAttack = true;
    private PlayerAnimator _playerAnimator;

    private void Start()
    {
        _inputReader.FirePressed += Attack;
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void OnDestroy()
    {
        _inputReader.FirePressed -= Attack;
    }

    private void Attack()
    {
        if (!_canAttack)
            return;

        Collider2D hit = Physics2D.OverlapCircle(transform.position, _radius, _layer);

        if (hit != null && hit.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_damage);
            _playerAnimator.EnableAttackParameter();
        }

        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_rate);
        _canAttack = true;
    }
}
