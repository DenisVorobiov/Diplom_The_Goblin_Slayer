﻿using FSM.AI.Actions;
using Unity.Burst;
using UnityEngine;


public class Guard : BaseAIController
{
    [SerializeField] private float aggroRange = 15.0f;
    [SerializeField] private float fireRange = 1.0f;
    [SerializeField] private float meleeDistance = 0.5f;
   
    public override StateMachine<State, object> GetBehaviour()
    {
        var statickPoint = new State();
        var fireState = new State();
        var shaseStates = new State();
      

        //patrol
        statickPoint.actions.Add(new StatickPoint(this));
        statickPoint.transitions.Add(
            new Transition<State, BaseCondition>(
                shaseStates,
                new DistanceCondition(this, aggroRange)));

        //chase
        shaseStates.actions.Add(new ChaseState(this));
        shaseStates.actions.Add(new LookAtAction(this));
        shaseStates.transitions.Add(new(fireState,
            new DistanceCondition(this, fireRange)));
        shaseStates.transitions.Add(
            new Transition<State, BaseCondition>(
                statickPoint,
                new DistanceCondition(this, aggroRange, false)));

        //fire
        fireState.actions.Add(new AttackAction(this));
        fireState.actions.Add(new LookAtAction(this));
        fireState.actions.Add(new KeepMeleeDistance(this, meleeDistance));
        fireState.transitions.Add(new(shaseStates,
            new DistanceCondition(this, fireRange, false)));
        

        return new StateMachine<State, object>(statickPoint);
    }
}