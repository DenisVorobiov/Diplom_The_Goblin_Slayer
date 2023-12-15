
    public class StopAction : BaseAction
    {
        public StopAction(BaseAIController controller) : base(controller)
        {
        }

        public override void Execute()
        {
            controller.agent.destination = controller.transform.position;
            float _speed = controller.agent.speed = 0.0f;
            controller.animator.SetFloat("Speed",_speed);
        }
    }
