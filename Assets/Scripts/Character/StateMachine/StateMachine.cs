using System;
using System.Collections.Generic;
using System.Linq;

public class StateMachine : IStateMachineUpdater, IStateChanger
{
    private Dictionary<Type, IExitableState> _states;
    private IExitableState _currentState;

    public void Initialize(List<IExitableState> states)
    {
        _states = states.ToDictionary(key => key.GetType(), value => value);
    }

    public void UpdateState()
    {
        if (_currentState is IUpdateState updateState)
            updateState.Update();
    }

    public void ChangeState<T>() where T : IExitableState, IEnterableState
    {
        if (_states.TryGetValue(typeof(T), out IExitableState newState))
        {
            Transition(newState);
            ((IEnterableState)newState).Enter();
        }
    }

    public void ChangeState<TState, TPayload>(TPayload payload)
        where TState : IEnterablePayloadState<TPayload>, IExitableState
        where TPayload : IPayload
    {
        if (_states.TryGetValue(typeof(TState), out IExitableState newState))
        {
            Transition(newState);
            ((IEnterablePayloadState<TPayload>)newState).Enter(payload);
        }
    }

    private void Transition(IExitableState newState)
    {
        if (newState == _currentState) return;

        _currentState?.Exit();
        _currentState = newState;
    }
}
