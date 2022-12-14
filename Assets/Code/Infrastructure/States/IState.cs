namespace Code.Infrastructure.States
{
    public interface IState : IExitableState
    {
        void Enter();
        void Tick(float deltaTime);
    }

    public interface IPayloadedState<TPayload> : IState
    {
        void Enter(TPayload payload);
    }

    public interface IExitableState
    {
        void Exit();
    }
}