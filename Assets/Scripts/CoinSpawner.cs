using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private float _spawnRate = 3f;

    private bool _hasCoin = false;
    private Coin coin;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void DestroyCoin()
    {
        coin.Picked -= DestroyCoin;
        Destroy(coin.gameObject);
        _hasCoin = false;
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds seconds = new(_spawnRate);

        while (enabled)
        {
            yield return seconds;

            if (!_hasCoin)
            {
                coin = Instantiate(_coin, transform.position, Quaternion.identity);
                coin.Picked += DestroyCoin;
                _hasCoin = true;
            }
        }
    }
}
