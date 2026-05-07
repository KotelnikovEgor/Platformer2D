using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private float _spawnRate = 3f;

    private Coin _coin;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void Respawn()
    {
        _coin.Collected -= Respawn;
        Destroy(_coin.gameObject);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_spawnRate);
        _coin = Instantiate(_coinPrefab, transform.position, Quaternion.identity);
        _coin.Collected += Respawn;
    }
}
