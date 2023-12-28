using UnityEngine;

public class StatickPoint : BaseAction
{
    public StatickPoint(BaseAIController controller) : base(controller)
    {
        
    }

    public override void Execute()
    {
        float _speed = controller.agent.speed = 0.0f;
        controller.animator.SetFloat("Speed",_speed);
        
        if (controller.agent != null && controller.agent.isActiveAndEnabled)
            controller.agent.SetDestination(controller.transform.position);
    }

  

}