using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseAction
{
    private float maxChaseDistance = 10.0f;
    private float returnDistance = 20.0f;
    
    public ChaseState(BaseAIController controller) : base(controller)
    {
       
    }

    public override void Execute()
    {
        float _speed = controller.agent.speed = 5.0f;   
        
        controller.animator.SetFloat("Speed",_speed);
        
        float distanceToPlayer = Vector3.Distance(controller.transform.position, controller.target.position);

        if (controller.agent != null && controller.agent.isActiveAndEnabled)
        {
            if (distanceToPlayer <= maxChaseDistance)
            {
                controller.agent.SetDestination(controller.target.position);

                if (distanceToPlayer > returnDistance)
                {
                    
                    controller.agent.SetDestination(controller.transform.position);
                }
            }
            else
            {
                controller.agent.SetDestination(controller.transform.position);
            }
        }
    }
}