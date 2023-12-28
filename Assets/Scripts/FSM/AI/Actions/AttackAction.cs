
    public class AttackAction : BaseAction
    {
          public AttackAction(BaseAIController controller) : base(controller)
        {
         
        }

        public override void Execute()
        {
            if (controller.agent != null && controller.agent.isActiveAndEnabled)
                controller.animator.SetTrigger("Attack");
        }
    }
    
