using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private LayerMask _layer;

    private readonly float _radius = 0.6f;
    private readonly float _rate = 1f;
    private readonly int _damage = 1;

    private bool _canAttack = true;

    private void Start()
    {
        _inputReader.FirePressed += Attack;
    }

    private void OnDisable()
    {
        _inputReader.FirePressed -= Attack;
    }

    private void Attack()
    {
        if (!_canAttack)
            return;

        Collider2D hit = Physics2D.OverlapCircle(transform.position, _radius, _layer);

        if (hit != null && hit.TryGetComponent(out EnemyHealth health))
            health.TakeDamage(_damage);

        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_rate);
        _canAttack = true;
    }
}
