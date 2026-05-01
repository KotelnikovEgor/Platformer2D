using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action Picked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
            Picked?.Invoke();
    }
}
