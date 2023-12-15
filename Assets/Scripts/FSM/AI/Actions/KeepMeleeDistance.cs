
public class KeepMeleeDistance : BaseAction
{
    private float _distance;

    public KeepMeleeDistance(BaseAIController controller, float distance) : base(controller)
    {
        _distance = distance;
    }

    public override void Execute()
    {
        var direction = controller.target.position - controller.transform.position;
        direction.Normalize();
        controller.agent.stoppingDistance = _distance;
    }
}
