using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public event Action MedicinePicked;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out _))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.TryGetComponent<Medicine>(out _))
        {
            Destroy(collision.gameObject);
            MedicinePicked?.Invoke();
        }
    }
}
