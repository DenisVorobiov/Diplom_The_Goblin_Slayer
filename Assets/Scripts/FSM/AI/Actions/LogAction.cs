using UnityEngine;

    public class LogAction : BaseAction
    {
        private string messege;

        public LogAction(BaseAIController controller, string msg) : base(controller)
        {
            messege = msg;
        }

        public override void Execute()
        {
            Debug.Log(messege);
        }
    }
