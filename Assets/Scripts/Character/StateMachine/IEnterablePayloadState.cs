public interface IEnterablePayloadState<TPayload> where TPayload : IPayload
{
    void Enter(TPayload payload);
}
