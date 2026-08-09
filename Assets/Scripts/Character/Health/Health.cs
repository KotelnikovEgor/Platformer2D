using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable, ITreatmentable, IRecoverable
{
    [SerializeField] private float _startValue;
    [SerializeField] private float _maxValue;

    public event Action Changed;
    public event Action Overed;

    public float Value { get; private set; }

    public float MaxValue { get; private set; }

    private void Awake()
    {
        Value = _startValue;
        MaxValue = _maxValue;
    }

    public void TakeDamage(int damage)
    {
        Value -= damage;
        Changed?.Invoke();

        if (Value <= 0)
            Overed?.Invoke();
    }

    public void GetTreatment(int treatment)
    {
        Value += treatment;
        Changed?.Invoke();
    }

    public void Recover()
    {
        Value = _startValue;
        Changed?.Invoke();
    }
}
