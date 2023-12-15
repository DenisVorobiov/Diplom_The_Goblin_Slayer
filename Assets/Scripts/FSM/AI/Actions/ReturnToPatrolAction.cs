using UnityEngine;

public class ReturnToPatrolAction : BaseAction
{
    private Vector3 patrolStartPosition;

    public ReturnToPatrolAction(BaseAIController controller) : base(controller)
    {
        patrolStartPosition = controller.transform.position; 
    }

    public override void Execute()
    {
        controller.agent.SetDestination(patrolStartPosition); 
    }
}