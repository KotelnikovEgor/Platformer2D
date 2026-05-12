using UnityEngine;

public abstract class BaseState : IExitableState
{
    protected readonly Transform _transform;
    protected readonly EnemyVision _enemyVision;

    protected StateMachine _stateMachine;

    protected BaseState(Transform transform, EnemyVision enemyVision)
    {
        _transform = transform;
        _enemyVision = enemyVision;
    }

    public abstract void Exit();

    public void SetStateMachine(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
}
