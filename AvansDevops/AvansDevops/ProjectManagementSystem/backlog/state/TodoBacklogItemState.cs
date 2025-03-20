using AvansDevops.ProjectManagementSystem.backlog;

namespace AvansDevops.ProjectManagementSystem.backlog.state
{
    public class TodoBacklogItemState : IBacklogItemState
    {
        private BacklogItem _backlogItem;
        public TodoBacklogItemState(BacklogItem backlogItem)
        {
            _backlogItem = backlogItem;
        }

        public void Approve()
        {
            Console.WriteLine("Backlog in TODO cannot be approved");
        }

        public void Complete()
        {
            Console.WriteLine("Backlog in TODO cannot be completed");
        }

        public void Deny()
        {
            Console.WriteLine("Backlog in TODO cannot be denied");
        }

        public void Start()
        {
            Console.WriteLine("Backlog item switched to doing");
            _backlogItem.currentState = _backlogItem.doingState;
        }
    }
}
