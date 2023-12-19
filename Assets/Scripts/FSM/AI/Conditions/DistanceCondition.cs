using UnityEngine;


    public class DistanceCondition : BaseCondition
    {
        private float _distance;
        private bool _isLess;

        public DistanceCondition(BaseAIController controller, float distance, bool isLess = true) : base(controller)
        {
            _distance = distance;
            _isLess = isLess;
        }

        public override bool Evaluate()
        {
            if (controller.target == null)
            {
                return false;
            }
            var currentDistance = Vector3.Distance(controller.transform.position, controller.target.position);
            return _isLess ? 
                currentDistance < _distance :
                currentDistance > _distance;
        }
    }
