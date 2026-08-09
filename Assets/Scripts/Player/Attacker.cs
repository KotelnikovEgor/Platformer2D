using System;
using UnityEngine;

public class Attacker : IDisposable
{
    private readonly InputReader _inputReader;
    private readonly Transform _transform;
    private readonly LayerMask _enemyLayer;
    private readonly PlayerAnimationSwitcher _animationSwitcher;
    private readonly float _radius = 1f;
    private readonly float _rate = 1f;
    private readonly int _damage = 20;

    private float _nextAttackTime;

    public Attacker(InputReader inputReader, Transform transform,  LayerMask enemyLayer, PlayerAnimationSwitcher animationSwitcher)
    {
        _inputReader = inputReader;
        _transform = transform;
        _enemyLayer = enemyLayer;
        _animationSwitcher = animationSwitcher;
        _inputReader.FirePressed += Attack;
    }

    public void Dispose()
    {
        _inputReader.FirePressed -= Attack;
    }

    private void Attack()
    {
        if (Time.time < _nextAttackTime) 
            return;

        Collider2D hit = Physics2D.OverlapCircle(_transform.position, _radius, _enemyLayer);

        if (hit != null && hit.TryGetComponent(out IDamageable damageable))
        {
            _animationSwitcher.EnableAttack();
            damageable.TakeDamage(_damage);
            _nextAttackTime = Time.time + _rate;
        }
    }
}
