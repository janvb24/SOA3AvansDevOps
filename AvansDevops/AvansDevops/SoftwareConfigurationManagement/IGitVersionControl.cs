namespace AvansDevops.SoftwareConfigurationManagement {
    public interface IGitVersionControl {
        /// <summary>
        /// Switches to the specified branch.
        /// </summary>
        /// <param name="branchName">The name of the branch to switch to.</param>
        public void Branch(string branchName);

        /// <summary>
        /// Commits the changes to the repository.
        /// </summary>
        /// <param name="message">The message to add to the commit</param>
        public void Commit(string message);

        /// <summary>
        /// Fetches the latest changes from the repository.
        /// </summary>
        public void Fetch();

        /// <summary>
        /// Push the changes to the repository.
        /// </summary>
        public void Push();
    }
}
