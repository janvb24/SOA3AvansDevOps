namespace AvansDevops.SoftwareConfigurationManagement.GitActions.CommitAction {
    public class CommitGitVersionControlAction : ICommitGitVersionControlAction {
        public void Commit(string message) {
            Console.WriteLine($"Committing changes with message: {message}");
        }
    }
}
