namespace AvansDevops.SoftwareConfigurationManagement.GitActions.FetchAction {
    public interface IFetchGitVersionControlAction {
        /// <summary>
        /// Fetches the latest changes from the repository.
        /// </summary>
        public void Fetch();
    }
}
