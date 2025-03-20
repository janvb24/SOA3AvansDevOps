namespace AvansDevops.ProjectManagementSystem.backlog.state
{
    public interface IBacklogItemState
    {
        /// <summary>
        /// Start a specific task of a backlog item
        /// </summary>
        public void Start();
        
        /// <summary>
        /// Complete a specific task of a backlog item
        /// </summary>
        public void Complete();

        /// <summary>
        /// Deny a specific task of a backlog item
        /// </summary>
        public void Deny();

        /// <summary>
        /// Approves a backlog item
        /// </summary>
        public void Approve();
    }
}
