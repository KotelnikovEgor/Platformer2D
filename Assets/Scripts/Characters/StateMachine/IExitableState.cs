public interface IExitableState
{
    void SetStateMachine(StateMachine stateMachine);

    void Exit();
}
