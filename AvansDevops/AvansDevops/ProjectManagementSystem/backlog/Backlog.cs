namespace AvansDevops.ProjectManagementSystem.backlog
{
    public class Backlog
    {
        private List<BacklogItem> _backlogItems = [];

        /// <summary>
        /// Adds backlogItem to the backlog
        /// </summary>
        /// <param name="backlogItem">Backlog item to add</param>
        public void AddBacklogItem(BacklogItem backlogItem) {
            _backlogItems.Add(backlogItem);
        }

        /// <summary>
        /// Removed backlogItem from the backlog
        /// </summary>
        /// <param name="backlogItem">Backlog item to remove</param>
        /// <returns>True if removed successfully, False if not</returns>
        public bool RemoveBacklogItem(BacklogItem backlogItem) {
            return _backlogItems.Remove(backlogItem);
        }

        /// <summary>
        /// Returns the backlog items
        /// </summary>
        /// <returns>list of type BacklogItem</returns>
        public List<BacklogItem> GetBacklogItems() {
            return _backlogItems;
        }
    }
}
