using System;
using System.Collections.Generic;
using System.Linq;

public class StateMachine
{
    private readonly Dictionary<Type, IExitableState> _states;

    private IExitableState _currentState;

    public StateMachine(List<IExitableState> states)
    {
        _states = states.ToDictionary(key => key.GetType(), value => value);
    }

    public void UpdateState()
    {
        if (_currentState is IUpdateState updateState)
            updateState.Update();
    }

    public void ChangeState<T>() where T : IExitableState
    {
        if (_states.TryGetValue(typeof(T), out IExitableState newState))
            ChangeState(newState);
    }

    public void ChangeState<TState, TPayload>(TPayload payload)
        where TState : IEnterablePayloadState<TPayload>, IExitableState
        where TPayload : ITransformPayload
    {
        if (_states.TryGetValue(typeof(TState), out IExitableState newState))
            ChangeState(newState, payload);
    }

    private void ChangeState(IExitableState newState, ITransformPayload payload = null)
    {
        if (newState == _currentState)
            return;

        _currentState?.Exit();
        _currentState = newState;

        if (_currentState is IEnterableState enterableState)
            enterableState.Enter();
        else if (_currentState is IEnterablePayloadState<ITransformPayload> enterablePayloadState)
            enterablePayloadState.Enter(payload);
    }
}
