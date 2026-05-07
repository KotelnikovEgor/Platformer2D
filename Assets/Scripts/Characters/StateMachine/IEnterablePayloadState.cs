public interface IEnterablePayloadState<TPayload> where TPayload : ITransformPayload
{
    void Enter(ITransformPayload payload);
}
