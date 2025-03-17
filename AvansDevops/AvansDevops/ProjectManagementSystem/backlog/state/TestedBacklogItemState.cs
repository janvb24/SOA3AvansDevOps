using AvansDevops.ProjectManagementSystem.backlog;

namespace AvansDevops.ProjectManagementSystem.backlog.state
{
    public class TestedBacklogItemState : IBacklogItemState
    {
        private BacklogItem _backlogItem;
        public TestedBacklogItemState(BacklogItem backlogItem)
        {
            _backlogItem = backlogItem;
        }

        public void Approve()
        {
            Console.WriteLine("Backlog item approved");
            _backlogItem.currentState = _backlogItem.doneState;
        }

        public void Complete()
        {
            Console.WriteLine("Backlog item in tested cannot be completed");
        }

        public void Deny()
        {
            Console.WriteLine("Backlog item in tested denied, switched to Ready for testing");
            _backlogItem.currentState = _backlogItem.readyForTestingState;
        }

        public void Start()
        {
            Console.WriteLine("Backlog item in tested cannot be started");
        }
    }
}
