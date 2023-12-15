public class StateChangeData<TState, TTrigger>
{
    public TState NewState { get; }
    public TState OldState { get; }
    public TTrigger ByTrigger { get; }

    public StateChangeData(TState newState, TState oldState, TTrigger byTrigger)
    {
        NewState = newState;
        OldState = oldState;
        ByTrigger = byTrigger;
    }
}