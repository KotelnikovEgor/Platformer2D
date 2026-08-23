using System;
using UnityEngine;

public class Health : MonoBehaviour, IValueChanger, IDamageable, ITreatmentable, IRecoverable
{
    [SerializeField] private float _startValue;
    [SerializeField] private float _maxValue;

    private float _currentValue;

    public event Action<float, float> Changed;
    public event Action Overed;

    private void Start()
    {
        _currentValue = _startValue;
    }

    public void TakeDamage(float damage)
    {
        _currentValue -= damage;
        Changed?.Invoke(_currentValue, _maxValue);

        if (_currentValue <= 0)
            Overed?.Invoke();
    }

    public void Treat(float treatment)
    {
        _currentValue += treatment;
        Changed?.Invoke(_currentValue, _maxValue);
    }

    public void Recover()
    {
        _currentValue = _startValue;
        Changed?.Invoke(_currentValue, _maxValue);
    }
}
