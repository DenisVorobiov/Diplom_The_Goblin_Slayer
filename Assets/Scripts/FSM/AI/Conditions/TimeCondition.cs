using UnityEngine;

public class TimeCondition : BaseCondition
{
    private float _duration;
    private float _startTime;

    public TimeCondition(BaseAIController controller, float duration) : base(controller)
    {
        _duration = duration;
        _startTime = Time.time;
    }

    public override bool Evaluate()
    {
        return Time.time - _startTime >= _duration;
    }
    
    public void InitializeExitTime()
    {
        _startTime = Time.time;
    }
}