using FSM.AI.Actions;
using UnityEngine;


    public class RangeEnemy : BaseAIController
    {
        [SerializeField] private float aggroRange = 15.0f;
        [SerializeField] private float fireRange = 6.0f;
        [SerializeField] private float time = 5;
        [SerializeField] private float keepDistance = 6;
        [SerializeField] private float look_speed = 1;

        public override StateMachine<State, object> GetBehaviour()
        {
            var patrulState = new State();
            var fireState = new State();
            var shaseStates = new State();
            var stopStates = new State();

            //patrol
            patrulState.actions.Add(new PatrolAction(this));
            patrulState.transitions.Add(
                new Transition<State, BaseCondition>(
                    shaseStates,
                    new DistanceCondition(this, aggroRange)));

            var patrolTimer = new TimeCondition(this, time);
            patrulState.OnEnter.Add(new LambdaAction(this, () => { patrolTimer.InitializeExitTime(); }));
            patrulState.transitions.Add(
                new Transition<State, BaseCondition>(
                    stopStates, patrolTimer));

            //chase
            shaseStates.actions.Add(new ChaseState(this));
            shaseStates.actions.Add(new LookAtAction(this,look_speed));
            shaseStates.transitions.Add(new(fireState,
                new DistanceCondition(this, fireRange)));
            shaseStates.transitions.Add(
                new Transition<State, BaseCondition>(
                    patrulState,
                    new DistanceCondition(this, aggroRange, false)));

            //fire
            fireState.actions.Add(new AttackAction(this));
            fireState.actions.Add(new LookAtAction(this,look_speed));
            fireState.actions.Add(new KeepDistance(this, keepDistance));
            fireState.transitions.Add(new(shaseStates,
                new DistanceCondition(this, fireRange, false)));


            //stop
            stopStates.actions.Add(new StopAction(this));
            var stopTimer = new TimeCondition(this, time);
            stopStates.OnEnter.Add(new LambdaAction(this, () => { stopTimer.InitializeExitTime(); }));
            stopStates.transitions.Add(new Transition<State, BaseCondition>(
                patrulState, stopTimer));


            return new StateMachine<State, object>(patrulState);
        }
    }
