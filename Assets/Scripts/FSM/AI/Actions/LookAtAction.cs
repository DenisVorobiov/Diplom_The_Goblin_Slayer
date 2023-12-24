using UnityEngine;

public class LookAtAction : BaseAction
{
    private float _distance;

    public LookAtAction(BaseAIController controller) : base(controller)
    {
       
    }

    public override void Execute()
    {
        float _speed = controller.agent.speed = 3.0f;
        controller.animator.SetFloat("Speed", _speed);
        
        if (controller.agent != null && controller.agent.isActiveAndEnabled)
        {
            controller.transform.LookAt(controller.target);
        }
        
    }
}