using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private LayerMask _layer;

    private readonly float _radius = 0.6f;
    private readonly float _rate = 1f;
    private readonly int _damage = 1;

    private bool _canAttack = true;
    private Animation _playerAnimation;

    private void Start()
    {
        _inputReader.FirePressed += Attack;
        _playerAnimation = GetComponent<Animation>();
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
            _playerAnimation.EnableAttackParameter();
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
