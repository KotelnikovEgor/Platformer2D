using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyPatrolState), typeof(EnemyPersecutionState))]
public class EnemyStateMachineFactory : MonoBehaviour
{
    private EnemyPatrolState _enemyPatrolState;
    private EnemyPersecutionState _enemyPersecutionState;

    private void Awake()
    {
        _enemyPatrolState = GetComponent<EnemyPatrolState>();
        _enemyPersecutionState = GetComponent<EnemyPersecutionState>();
        Create();
    }

    public void Create()
    {
        List<IExitableState> states = new()
        {
            _enemyPatrolState,
            _enemyPersecutionState
        };

        StateMachine stateMachine = new(states);

        foreach (IExitableState state in states)
        {
            state.SetStateMachine(stateMachine);
        }

        stateMachine.ChangeState<EnemyPatrolState>();
    }
}
