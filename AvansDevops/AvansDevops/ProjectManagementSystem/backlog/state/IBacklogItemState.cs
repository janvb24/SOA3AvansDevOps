namespace AvansDevops.ProjectManagementSystem.backlog.state
{
    public interface IBacklogItemState
    {
        public void Start();
        public void Complete();
        public void Deny();
        public void Approve();
    }
}
