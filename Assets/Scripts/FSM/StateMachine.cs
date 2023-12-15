using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<TState, TTrigger>
{
    public TState CurrentState { get; set; }
    public event Action<StateChangeData<TState, TTrigger>> OnStateChange;
    private Dictionary<TState, List<Transition<TState, TTrigger>>> _transitions = new();

    public StateMachine(TState initialState)
    {
        CurrentState = initialState;
    }

    public void SetTrigger(TTrigger trigger)
    {
        if (!_transitions.ContainsKey(CurrentState))
        {
            Debug.LogAssertion($"There is no exit from state {CurrentState}");
            return;
        }

        foreach (var transition in _transitions[CurrentState])
        {
            if (transition.Trigger.Equals(trigger))
            {
                var prevState = CurrentState;
                CurrentState = transition.NextState;
                OnStateChange?.Invoke(new(CurrentState, prevState, trigger));
                return;
            }
        }

        Debug.LogAssertion($"There is no exit from state {CurrentState} by trigger {trigger}");
    }

    public void AddTransition(TState from, TTrigger byTrigger, TState to)
    {
        if (!_transitions.ContainsKey(from))
            _transitions.Add(from, new());

        foreach (var transition in _transitions[from])
        {
            if (transition.Trigger.Equals(byTrigger))
            {
                Debug.LogAssertion($"The transition from state {from} by trigger {byTrigger} is already exists");
                return;
            }
        }

        _transitions[from].Add(new Transition<TState, TTrigger>(to, byTrigger));
    }
}