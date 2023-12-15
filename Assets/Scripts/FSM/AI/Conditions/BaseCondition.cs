
    public abstract class BaseCondition
    {
        protected BaseAIController controller;

        public BaseCondition(BaseAIController controller)
        {
            this.controller = controller;
        }

        public abstract bool Evaluate();
    }
