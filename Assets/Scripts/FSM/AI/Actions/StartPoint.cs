using UnityEngine;
using UnityEngine.AI;

public class StartPoint : BaseAction
{
   private float maxDistance = 10;
    private Vector3 startPosition;

    public StartPoint(BaseAIController controller, float maxDistance, Vector3 initialPosition) : base(controller) 
    {
        this.maxDistance = maxDistance;
        startPosition = initialPosition;
    }

    public override void Execute()
    {
        float distance = Vector3.Distance(controller.transform.position, controller.target.position);

        if (distance > maxDistance)
        {
            
            controller.agent.SetDestination(startPosition);
        }
    }
}