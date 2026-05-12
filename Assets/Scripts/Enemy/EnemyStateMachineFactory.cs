using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachineFactory
{
    private readonly EnemyAnimator _enemyAnimator;
    private readonly EnemyVision _enemyVision;
    private readonly Fliper _fliper;
    private readonly Transform _transform;
    private readonly Transform[] _targetPoints;

    public EnemyStateMachineFactory(EnemyAnimator enemyAnimation, EnemyVision enemyVision, Fliper fliper, Transform transform, Transform[] targetPoints)
    {
        _enemyAnimator = enemyAnimation;
        _enemyVision = enemyVision;
        _fliper = fliper;
        _transform = transform;
        _targetPoints = targetPoints;
    }

    public StateMachine Create()
    {
        List<IExitableState> states = new()
        {
            new EnemyPatrolState(_fliper, _enemyVision, _transform, _targetPoints),
            new EnemyPersecutionState(_enemyVision, _transform),
            new EnemyAttackState(_enemyAnimator, _enemyVision, _transform)
        };

        StateMachine stateMachine = new(states);

        foreach (IExitableState state in states)
        {
            state.SetStateMachine(stateMachine);
        }

        stateMachine.ChangeState<EnemyPatrolState>();

        return stateMachine;
    }
}
