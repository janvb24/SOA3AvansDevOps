namespace AvansDevops.SoftwareConfigurationManagement.GitActions.CommitAction {
    public interface ICommitGitVersionControlAction {
        /// <summary>
        /// Commits the changes
        /// </summary>
        /// <param name="message">Message to add to commit</param>
        public void Commit(string message);
    }
}
