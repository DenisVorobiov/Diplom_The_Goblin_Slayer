using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;


    public abstract class BaseAIController : MonoBehaviour
    {
        public NavMeshAgent agent;
      
        public Animator animator;
        public List<Transform> StaticPatrolPoints;
        public List<Vector3> patrolPoints = new();
        [SerializeField] private LayerMask targetLayerMask;
        
        private float _range = 15;

    public StateMachine<State, object> _stateMachine;
    public Transform target;


    private void Awake()
        {
       
        _stateMachine = GetBehaviour();
      
        }

        public abstract StateMachine<State, object> GetBehaviour();

        public void Update()
        {
            var hitTargets = Physics.OverlapSphere(transform.position, _range, targetLayerMask);

            if (hitTargets.Length > 0)
            {
                var ordered = hitTargets.OrderBy(t => Vector3.Distance(transform.position, t.transform.position));

                Transform closestTarget = ordered.First().transform;

                SetTarget(closestTarget);
            }
                
            _stateMachine.CurrentState.Execute();
            var nextState = _stateMachine.CurrentState.TryGetNextState();
            if (nextState != null)
            {
                _stateMachine.CurrentState.OnStateExit();
                _stateMachine.CurrentState = nextState;
                _stateMachine.CurrentState.OnStateEnter();
            }
        }
        private void SetTarget(Transform target)
        {
            
            this.target = target;

        }
    
}
