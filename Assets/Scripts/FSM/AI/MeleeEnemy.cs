using Unity.Burst;
using UnityEngine;


public class MeleeEnemy : BaseAIController
{
    [SerializeField] private float aggroRange = 15.0f;
    [SerializeField] private float fireRange = 2.0f;
    [SerializeField] private float meleeDistance = 1.0f;
    [SerializeField] private float time = 5;
    [SerializeField] private float time1 = 10;
        
    public override StateMachine<State, object> GetBehaviour()
    {
        var patrulState = new State();
        var fireState = new State();
        var shaseStates = new State();
        var stopStates = new State();
            
            
        patrulState.actions.Add(new PatrolAction(this));
            
        patrulState.transitions.Add(
            new Transition<State, BaseCondition>(
                shaseStates,
                new DistanceCondition(this, aggroRange)));

        shaseStates.actions.Add(new ChaseState(this));
        
        shaseStates.transitions.Add(new(fireState,
            new DistanceCondition(this, fireRange)));

        fireState.actions.Add(new AttackAction(this));
        fireState.actions.Add(new KeepMeleeDistance(this, meleeDistance));

        fireState.transitions.Add(new(shaseStates,
            new DistanceCondition(this, fireRange, false)));

        shaseStates.transitions.Add(
            new Transition<State, BaseCondition>(
                patrulState,
                new DistanceCondition(this, aggroRange,false)));

        patrulState.transitions.Add(
            new Transition<State, BaseCondition>(
                stopStates,
                new TimeCondition(this, time)));
        stopStates.actions.Add(new StopAction(this));
        
        stopStates.transitions.Add(new Transition<State, BaseCondition>(
            patrulState,
            new TimeCondition(this,time )));
        
        return new StateMachine<State, object>(patrulState);
    }
}