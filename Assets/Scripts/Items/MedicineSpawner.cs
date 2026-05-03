using System.Collections;
using UnityEngine;

public class MedicineSpawner : MonoBehaviour
{
    [SerializeField] private Medicine _medicinePrefab;

    private readonly float _yPosition = 5.5f;
    private readonly float _xPosition = 8f;
    private readonly float _rate = 5f;

    private Medicine _medicine;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void Respawn()
    {
        _medicine.Destroying -= Respawn;
        StartCoroutine(Spawn());
    }

    private Vector3 GeneratePosition()
    {
        return new Vector2(Random.Range(-_xPosition, _xPosition), _yPosition);   
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_rate);
        _medicine = Instantiate(_medicinePrefab, GeneratePosition(), Quaternion.identity);
        _medicine.Destroying += Respawn;
    }
}
