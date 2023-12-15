

    public class KeepDistance : BaseAction
    {
        private float _distance;

        public KeepDistance(BaseAIController controller, float distance) : base(controller)
        {
            _distance = distance;
        }

        public override void Execute()
        {
            var direction = controller.target.position - controller.transform.position;
            direction.Normalize();
            direction *= _distance;
            controller.agent.destination = controller.target.position - direction;
        }
    }
