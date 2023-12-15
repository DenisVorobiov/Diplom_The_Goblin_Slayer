using System.Collections.Generic;


    public class State
    {
        public List<BaseAction> actions = new();
        public List<Transition<State, BaseCondition>> transitions = new();
        public List<BaseAction> OnEnter = new();
        public List<BaseAction> OnExit = new();


        public void Execute()
        {
            foreach (var act in actions)
            {
                act.Execute();
            }
        }

        public State TryGetNextState()
        {
            foreach (var transition in transitions)
            {
                if (transition.Trigger.Evaluate())
                {
                    return transition.NextState;
                }
            }

            return default;
        }

        public void OnStateEnter()
        {
            foreach (var act in OnEnter)
            {
                act.Execute();
            }
        }
        
        public void OnStateExit()
        {
            foreach (var act in OnExit)
            {
                act.Execute();
            }
        }
    }
