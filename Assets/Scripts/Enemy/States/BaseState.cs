using UnityEngine;

public abstract class BaseState : IExitableState
{
    protected readonly IStateChanger StateMachine;
    protected readonly Transform Transform;
    protected readonly EnemyVision Vision;

    protected BaseState(IStateChanger stateChanger, Transform transform, EnemyVision vision)
    {
        StateMachine = stateChanger;
        Transform = transform;
        Vision = vision;
    }

    public abstract void Exit();
}
