using UnityEngine;

[RequireComponent(typeof(Health))]
public class Collector : MonoBehaviour
{
    private Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            coin.Collect();
        }
        else if (collision.gameObject.TryGetComponent(out Medicine medicine))
        {
            _health.GetTreatment(medicine.Treatment);
            medicine.Collect();
        }
    }
}
