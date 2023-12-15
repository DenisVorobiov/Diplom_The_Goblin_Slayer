using UnityEngine;

public class CombinedCondition : BaseCondition
{
    private float _distance;
    private bool _isLess;
    private float _duration;
    private float _startTime;

    public CombinedCondition(BaseAIController controller, float distance, bool isLess = true, float duration = 0) : base(controller)
    {
        _distance = distance;
        _isLess = isLess;
        _duration = duration;
        _startTime = Time.time;
    }

    public override bool Evaluate()
    {
        var distanceCondition = EvaluateDistanceCondition();
        var timeCondition = EvaluateTimeCondition();

        return distanceCondition || timeCondition;
    }

    private bool EvaluateDistanceCondition()
    {
        var currentDistance = Vector3.Distance(controller.transform.position, controller.target.position);
        return _isLess ? currentDistance < _distance : currentDistance > _distance;
    }

    private bool EvaluateTimeCondition()
    {
        return Time.time - _startTime >= _duration;
    }
}