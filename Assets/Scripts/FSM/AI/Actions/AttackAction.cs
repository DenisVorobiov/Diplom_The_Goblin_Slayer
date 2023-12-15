
    public class AttackAction : BaseAction
    {
          public AttackAction(BaseAIController controller) : base(controller)
        {
         
        }

        public override void Execute()
        {

        if (controller.animator != null)
         
             controller.animator.SetTrigger("Attack");
        
        }
    }
    
