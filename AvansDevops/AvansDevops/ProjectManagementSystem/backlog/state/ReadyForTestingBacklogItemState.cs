using AvansDevops.ProjectManagementSystem.backlog;

namespace AvansDevops.ProjectManagementSystem.backlog.state
{
    public class ReadyForTestingBacklogItemState : IBacklogItemState
    {
        private BacklogItem _backlogItem;
        public ReadyForTestingBacklogItemState(BacklogItem backlogItem)
        {
            _backlogItem = backlogItem;
        }

        public void Approve()
        {
            Console.WriteLine("Backlog item in ready for testing cannot be approved");
        }

        public void Complete()
        {
            Console.WriteLine("Backlog item in ready for testing cannot be completed");
        }

        public void Deny()
        {
            Console.WriteLine("Backlog item in ready for testing cannot be denied");
        }

        public void Start()
        {
            Console.WriteLine("Backlog item switched to testing");
            _backlogItem.currentState = _backlogItem.testingState;
        }
    }
}
