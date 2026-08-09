using UnityEngine;

public abstract class BaseState : IExitableState
{
    protected readonly IStateChanger _stateMachine;
    protected readonly Transform _transform;
    protected readonly EnemyVision _vision;

    protected BaseState(IStateChanger stateChanger, Transform transform, EnemyVision vision)
    {
        _stateMachine = stateChanger;
        _transform = transform;
        _vision = vision;
    }

    public abstract void Exit();
}
