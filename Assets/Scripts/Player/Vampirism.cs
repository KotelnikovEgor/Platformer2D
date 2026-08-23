using System;
using UnityEngine;

public class Vampirism : IValueChanger, IDisposable
{
    private readonly Transform _transform;
    private readonly LayerMask _enemyLayer;
    private readonly Health _health;
    private readonly InputReader _inputReader;
    private readonly GameObject _visualizer;
    private readonly float _scale = 4f;
    private readonly float _damage = 5;
    private readonly float _duration = 6f;
    private readonly float _cooldown = 4f;
    private bool _isActive;
    private bool _isCooldown;
    private float _timer;

    public event Action<float, float> Changed;

    public Vampirism(Transform transform, LayerMask enemyLayer, Health health, InputReader inputReader, GameObject visualizer)
    {
        _transform = transform;
        _enemyLayer = enemyLayer;
        _health = health;
        _inputReader = inputReader;
        _inputReader.VampirismKeyPressed += Perform;
        _visualizer = visualizer;
        _visualizer.SetActive(false);
        _visualizer.transform.localScale = new Vector3(_scale, _scale, 1);
    }

    public void Update()
    {
        if (_isActive)
        {
            _timer -= Time.deltaTime;
            Changed?.Invoke(_timer, _duration);

            if (_timer <= 0)
            {
                _isActive = false;
                _isCooldown = true;
                _timer = 0f;
                _visualizer.SetActive(false);
            }
        }
        else if (_isCooldown)
        {
            _timer += Time.deltaTime;
            Changed?.Invoke(_timer, _cooldown);

            if (_timer >= _cooldown)
            {
                _isCooldown = false;
            }
        }

        if (_isActive)
            DrainHealth();
    }

    private void Perform()
    {
        if (!_isActive && !_isCooldown)
        {
            _isActive = true;
            _timer = _duration;
            _visualizer.SetActive(true);
        }
    }

    private void DrainHealth()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_transform.position, _scale / 2, _enemyLayer);
        Transform closestEnemy = GetClosestEnemy(enemies);

        if (closestEnemy != null)
        {
            if (closestEnemy.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(_damage * Time.deltaTime);
            }

            _health.Treat(_damage * Time.deltaTime);
        }
    }

    private Transform GetClosestEnemy(Collider2D[] enemies)
    {
        Transform bestTarget = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D enemy in enemies)
        {
            float distanceToTarget = (enemy.transform.position - _transform.position).sqrMagnitude;

            if (distanceToTarget < closestDistance)
            {
                closestDistance = distanceToTarget;
                bestTarget = enemy.transform;
            }
        }

        return bestTarget;
    }

    public void Dispose()
    {
        _inputReader.VampirismKeyPressed -= Perform;
    }
}
