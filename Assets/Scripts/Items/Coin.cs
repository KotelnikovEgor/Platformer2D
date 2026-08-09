using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
{
    public void Collect(Collector collector)
    {
        Destroy(gameObject);
    }
}
