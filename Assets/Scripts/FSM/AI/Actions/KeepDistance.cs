

    public class KeepDistance : BaseAction
    {
        private float _distance;

        public KeepDistance(BaseAIController controller, float distance) : base(controller)
        {
            _distance = distance;
        }

        public override void Execute()
        {
            float _speed = controller.agent.speed = 2.0f;
            controller.animator.SetFloat("Speed", _speed);
            
            if (controller.agent != null && controller.agent.isActiveAndEnabled)
            {
                var direction = controller.target.position - controller.transform.position;
                direction.Normalize();
                direction *= _distance;
                controller.agent.destination = controller.target.position - direction;
            }
            
        }
    }
