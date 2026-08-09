using System;
using UnityEngine;

public class EnemyDeath : IDisposable
{
    private readonly Health _health;
    private readonly GameObject _gameObject;

    public EnemyDeath(Health health, GameObject gameObject)
    {
        _health = health;
        _health.Overed += Die;
        _gameObject = gameObject;
    }

    public void Dispose()
    {
        _health.Overed -= Die;
    }

    private void Die()
    {
        UnityEngine.Object.Destroy(_gameObject);
    }
}
