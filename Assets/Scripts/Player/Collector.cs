using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out _))
            Destroy(collision.gameObject);
    }
}
