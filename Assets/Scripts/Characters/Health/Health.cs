using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    private readonly int _startHealth = 3;

    private int _healthValue;

    public event Action Overed;

    private void Start()
    {
        _healthValue = _startHealth;
    }

    public void TakeDamage(int damage)
    {
        _healthValue -= damage;

        if (_healthValue <= 0)
            Overed?.Invoke();
    }

    public void GetTreatment(int treatment)
    {
        _healthValue += treatment;
    }

    public void Recover()
    {
        _healthValue = _startHealth;
    }
}
