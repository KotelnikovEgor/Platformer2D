using UnityEngine;

[RequireComponent(typeof(Health))]
public class EnemyDead : MonoBehaviour
{
    private Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();
        _health.Overed += Die;
    }

    private void OnDestroy()
    {
        _health.Overed -= Die;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
