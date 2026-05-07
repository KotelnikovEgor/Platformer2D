using UnityEngine;

[RequireComponent(typeof(Health))]
public class Dead : MonoBehaviour
{
    private Health _health;
    private Vector3 _startPosition;

    private void Start()
    {
        _health = GetComponent<Health>();
        _health.Overed += Die;
        _startPosition = transform.position;
    }

    private void OnDestroy()
    {
        _health.Overed -= Die;
    }

    private void Die()
    {
        _health.Recover();
        transform.position = _startPosition;
    }
}
