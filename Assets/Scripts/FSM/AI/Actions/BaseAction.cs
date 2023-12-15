
    public abstract class BaseAction
    {
        protected BaseAIController controller;

        public BaseAction(BaseAIController controller)
        {
            this.controller = controller;
        }

        public abstract void Execute();
    }
