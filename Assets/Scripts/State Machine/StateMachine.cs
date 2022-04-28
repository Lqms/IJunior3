public class StateMachine
{
    public State CurrentState { get; set; }

    public void Initialize(State startState)
    {
        CurrentState = startState;
    }

    public void ChangeState(State newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}