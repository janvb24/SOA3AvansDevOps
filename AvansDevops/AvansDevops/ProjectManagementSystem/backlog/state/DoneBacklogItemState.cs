using AvansDevops.ProjectManagementSystem.backlog;

namespace AvansDevops.ProjectManagementSystem.backlog.state
{
    public class DoneBacklogItemState : IBacklogItemState
    {
        private BacklogItem _backlogItem;
        public DoneBacklogItemState(BacklogItem backlogItem)
        {
            _backlogItem = backlogItem;
        }

        public void Approve()
        {
            Console.WriteLine("Backlog item is already done");
        }

        public void Complete()
        {
            Console.WriteLine("Backlog item is already done");

        }

        public void Deny()
        {
            Console.WriteLine("Backlog item is already done");
        }

        public void Start()
        {
            Console.WriteLine("Backlog item is already done");
        }
    }
}
