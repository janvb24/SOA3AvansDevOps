namespace AvansDevops.SoftwareConfigurationManagement.GitActions.FetchAction {
    public class FetchGitVersionControlAction : IFetchGitVersionControlAction {
        public void Fetch() {
            Console.WriteLine("Fetching the latest changes from the repository.");
        }
    }
}
