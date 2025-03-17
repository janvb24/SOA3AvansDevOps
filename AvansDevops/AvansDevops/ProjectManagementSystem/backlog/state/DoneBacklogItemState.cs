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
            throw new NotImplementedException();
        }

        public void Complete()
        {
            throw new NotImplementedException();
        }

        public void Deny()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}
