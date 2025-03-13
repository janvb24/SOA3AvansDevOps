namespace AvansDevops.SoftwareConfigurationManagement.GitActions.BranchAction {
    public class BranchGitVersionControlAction : IBranchGitVersionControlAction {
        public void Branch(string branchName) {
            Console.WriteLine($"Branching to branch {branchName}");
        }
    }
}
