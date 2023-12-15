
using UnityEngine;

public class StopChasingAction : BaseAction
{
    private float maxDistance = 10; 

    public StopChasingAction(BaseAIController controller, float maxDistance) : base(controller)
    {
        this.maxDistance = maxDistance;
    }

    public override void Execute()
    {

        controller.agent.SetDestination(controller.target.position);
        float distance = Vector3.Distance(controller.transform.position, controller.target.position);


        if (distance > maxDistance)
        {
           
            controller.agent.ResetPath();
        }
    }
}
