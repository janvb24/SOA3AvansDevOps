namespace AvansDevops.SoftwareConfigurationManagement.GitActions.BranchAction {
    public interface IBranchGitVersionControlAction {
        /// <summary>
        /// Git action to go to a branch with specified name.
        /// </summary>
        /// <param name="branchName"></param>
        public void Branch(string branchName);

    }
}
