using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


    public abstract class BaseAIController : MonoBehaviour
    {
        public NavMeshAgent agent;
        public Transform target;
        public Animator animator;
        public List<Transform> StaticPatrolPoints;
        public List<Vector3> patrolPoints = new();
        


    public StateMachine<State, object> _stateMachine;

        private void Awake()
        {
        
        target = GameObject.FindWithTag("Player").transform;
       
        _stateMachine = GetBehaviour();
      
        }

        public abstract StateMachine<State, object> GetBehaviour();

        public void Update()
        {
                
            _stateMachine.CurrentState.Execute();
            var nextState = _stateMachine.CurrentState.TryGetNextState();
            if (nextState != null)
            {
                _stateMachine.CurrentState.OnStateExit();
                _stateMachine.CurrentState = nextState;
                _stateMachine.CurrentState.OnStateEnter();
            }
        }
    
}
