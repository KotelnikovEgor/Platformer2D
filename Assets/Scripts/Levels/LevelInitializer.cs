using UnityEngine;

public class LevelInitializer : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform[] _targetPoints;

    private void Awake()
    {
        InitializeEnemy();
    }

    private void InitializeEnemy()
    {
        EnemyStateMachineFactory enemyStateMachineFactory = new(_enemy.EnemyAnimation, _enemy.EnemyVision, _enemy.Fliper, _enemy.transform, _targetPoints);
        StateMachine stateMachine = enemyStateMachineFactory.Create();
        _enemy.Construct(stateMachine);
    }
}
