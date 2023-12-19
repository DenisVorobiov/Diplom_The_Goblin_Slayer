using UnityEngine;

public class PatrolAction : BaseAction
{
    private int currentPatrolIndex;
    private const float DestinationReachedThreshold = 1.0f;

    public PatrolAction(BaseAIController controller) : base(controller)
    {
        currentPatrolIndex = 0;
        
    }

    public override void Execute()
    {
        float _speed = controller.agent.speed = 1.0f;
        controller.animator.SetFloat("Speed",_speed);
        
        if (controller.patrolPoints.Count > 0)
        {
            MoveToNextPatrolPoint();
        }
    }

    private void MoveToNextPatrolPoint()
    {
        if (controller.agent != null && controller.agent.isActiveAndEnabled)
        {
            controller.agent.SetDestination(controller.patrolPoints[currentPatrolIndex]);
        }
        
        if (Vector3.Distance(controller.transform.position, controller.patrolPoints[currentPatrolIndex]) < DestinationReachedThreshold)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % controller.patrolPoints.Count;
        }
        
    }
}