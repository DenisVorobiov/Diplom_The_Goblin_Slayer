public class Transition<TState, TTrigger>
{
    public TState NextState { get; }
    public TTrigger Trigger { get; }

    public Transition(TState nextState, TTrigger trigger)
    {
        NextState = nextState;
        Trigger = trigger;
    }
}