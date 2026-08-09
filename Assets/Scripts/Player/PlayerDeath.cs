using System;
using UnityEngine;

public class PlayerDeath : IDisposable
{
    private readonly IRecoverable _health;
    private readonly Vector3 _startPosition;
    private readonly Transform _transform;

    public PlayerDeath(IRecoverable health, Vector3 startPosition, Transform transform)
    {
        _health = health;
        _health.Overed += Die;
        _startPosition = startPosition;
        _transform = transform;
    }

    public void Dispose()
    {
        _health.Overed -= Die;
    }

    private void Die()
    {
        _health.Recover();
        _transform.position = _startPosition;
    }
}
