using UnityEngine;

public class LookAtAction : BaseAction
{
    private float _distance;
    private float _sspeed;

    public LookAtAction(BaseAIController controller, float speed) : base(controller)
    {
        _sspeed = speed;
    }

    public override void Execute()
    {
        float _speed = controller.agent.speed = _sspeed;
        controller.animator.SetFloat("Speed", _speed);
        
        if (controller.agent != null && controller.agent.isActiveAndEnabled)
            controller.transform.LookAt(controller.target);
        
        
    }
}