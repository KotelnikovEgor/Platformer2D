using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    private readonly int _startValue = 3;

    private int _currentValue;

    public event Action Overed;

    private void Start()
    {
        _currentValue = _startValue;
    }

    public void TakeDamage(int damage)
    {
        _currentValue -= damage;

        if (_currentValue <= 0)
            Overed?.Invoke();
    }

    public void GetTreatment(int treatment)
    {
        _currentValue += treatment;
    }

    public void Recover()
    {
        _currentValue = _startValue;
    }
}
