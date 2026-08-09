public interface IStateChanger
{
    void ChangeState<T>() where T : IExitableState, IEnterableState;

    public void ChangeState<TState, TPayload>(TPayload payload)
        where TState : IEnterablePayloadState<TPayload>, IExitableState
        where TPayload : IPayload;
}
