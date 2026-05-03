using UnityEngine;

[RequireComponent(typeof(Collector))]
public class Health : MonoBehaviour
{
    [SerializeField] private int _health = 3;

    private readonly int _treatment = 1;

    private int _maxHealth;
    private Vector3 _startPosition;
    private Collector _collector;

    private void Start()
    {
        _maxHealth = _health;
        _startPosition = transform.position;
        _collector = GetComponent<Collector>();
        _collector.MedicinePicked += GetTreatment;
    }

    private void OnDisable()
    {
        _collector.MedicinePicked -= GetTreatment;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Die();
    }

    private void GetTreatment()
    {
        _health += _treatment;
    }

    private void Die()
    {
        _health = _maxHealth;
        transform.position = _startPosition;
    }
}
