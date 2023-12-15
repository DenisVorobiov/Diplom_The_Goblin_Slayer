
    public class GoToTargetAction : BaseAction
    {
        public GoToTargetAction(BaseAIController controller) : base(controller)
        {
        }

        public override void Execute()
        {
            controller.agent.destination = controller.target.position;
        }
    }
