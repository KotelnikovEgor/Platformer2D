using UnityEngine;

[RequireComponent(typeof(EnemyPatrol), typeof(EnemyPersecution), typeof(EnemyVision))]
public class EnemyStates : MonoBehaviour
{
    private EnemyPatrol _enemyPatrol;
    private EnemyPersecution _enemyPersecution;
    private EnemyVision _enemyVision;

    private void Start()
    {
        _enemyPatrol = GetComponent<EnemyPatrol>();
        _enemyPersecution = GetComponent<EnemyPersecution>();
        _enemyVision = GetComponent<EnemyVision>();

        _enemyVision.Seessing += SetPersecution;
        _enemyVision.Unsawed += SetPatrol;

        _enemyPersecution.enabled = false;
    }

    private void OnDisable()
    {
        _enemyVision.Seessing -= SetPersecution;
        _enemyVision.Unsawed -= SetPatrol;
    }

    private void SetPatrol()
    {
        _enemyPersecution.enabled = false;
        _enemyPatrol.enabled = true;
    }

    private void SetPersecution()
    {
        _enemyPatrol.enabled = false;
        _enemyPersecution.enabled = true;
    }
}
