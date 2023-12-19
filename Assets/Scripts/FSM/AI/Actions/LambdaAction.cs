using System;

namespace FSM.AI.Actions
{
    public class LambdaAction : BaseAction
    {
        private event Action _action;

        public LambdaAction(BaseAIController controller, Action action) : base(controller)
        {
            _action = action;
        }

        public override void Execute()
        {
            _action?.Invoke();
        }
    }
}