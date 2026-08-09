using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachineFactory
{
    private readonly EnemyAnimationSwitcher _animationSwitcher;
    private readonly EnemyVision _vision;
    private readonly Transform _transform;
    private readonly Vector3[] _targetPoints;
    private readonly Fliper _fliper;

    public EnemyStateMachineFactory(EnemyAnimationSwitcher animationSwitcher, EnemyVision vision, Transform transform, Vector3[] targetPoints, Fliper fliper)
    {
        _animationSwitcher = animationSwitcher;
        _vision = vision;
        _transform = transform;
        _targetPoints = targetPoints;
        _fliper = fliper;
    }

    public StateMachine Create()
    {
        StateMachine stateMachine = new();

        List<IExitableState> states = new()
        {
            new PatrolState(stateMachine, _transform, _vision, _targetPoints, _fliper),
            new PersecutionState(stateMachine, _transform, _vision),
            new AttackState(stateMachine, _transform, _vision, _animationSwitcher)
        };

        stateMachine.Initialize(states);
        stateMachine.ChangeState<PatrolState>();
        return stateMachine;
    }
}
