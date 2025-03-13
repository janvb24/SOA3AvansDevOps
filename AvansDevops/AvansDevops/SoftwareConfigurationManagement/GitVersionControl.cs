using AvansDevops.SoftwareConfigurationManagement.GitActions.BranchAction;
using AvansDevops.SoftwareConfigurationManagement.GitActions.CommitAction;
using AvansDevops.SoftwareConfigurationManagement.GitActions.FetchAction;
using AvansDevops.SoftwareConfigurationManagement.GitActions.PushAction;

namespace AvansDevops.SoftwareConfigurationManagement {
    public class GitVersionControl : IGitVersionControl {
        private readonly IBranchGitVersionControlAction branchGitVersionControlAction;
        private readonly ICommitGitVersionControlAction commitGitVersionControlAction;
        private readonly IFetchGitVersionControlAction fetchGitVersionControlAction;
        private readonly IPushGitVersionControlAction pushGitVersionControlAction;

        public GitVersionControl(IBranchGitVersionControlAction branchGitVersionControlAction, ICommitGitVersionControlAction commitGitVersionControlAction, IFetchGitVersionControlAction fetchGitVersionControlAction, IPushGitVersionControlAction pushGitVersionControlAction) {
            this.branchGitVersionControlAction = branchGitVersionControlAction;
            this.commitGitVersionControlAction = commitGitVersionControlAction;
            this.fetchGitVersionControlAction = fetchGitVersionControlAction;
            this.pushGitVersionControlAction = pushGitVersionControlAction;
        }

        public void Branch(string branchName) {
            branchGitVersionControlAction.Branch(branchName);
        }

        public void Commit(string message) {
            commitGitVersionControlAction.Commit(message);
        }

        public void Fetch() {
            fetchGitVersionControlAction.Fetch();
        }

        public void Push() {
            pushGitVersionControlAction.Push();
        }
    }
}
