using AvansDevops.SoftwareConfigurationManagement;
using AvansDevops.SoftwareConfigurationManagement.GitActions.BranchAction;
using AvansDevops.SoftwareConfigurationManagement.GitActions.CommitAction;
using AvansDevops.SoftwareConfigurationManagement.GitActions.FetchAction;
using AvansDevops.SoftwareConfigurationManagement.GitActions.PushAction;

namespace AvansDevopsTests.SoftwareConfigurationManagement {
    public class GitVersionControlTests {
        [Fact]
        public void ShouldBranchUsingBranchAction() {
            //Arrange
            var branchAction = Substitute.For<IBranchGitVersionControlAction>();
            var commitAction = Substitute.For<ICommitGitVersionControlAction>();
            var fetchAction = Substitute.For<IFetchGitVersionControlAction>();
            var pushAction = Substitute.For<IPushGitVersionControlAction>();
            IGitVersionControl gitVersionControl = new GitVersionControl(branchAction, commitAction, fetchAction, pushAction);
            string branchName = "TestBranch";

            //Act
            gitVersionControl.Branch(branchName);

            //Assert
            branchAction.Received(1).Branch(branchName);
        }

        [Fact]
        public void ShouldCommitUsingBranchAction() {
            //Arrange
            var branchAction = Substitute.For<IBranchGitVersionControlAction>();
            var commitAction = Substitute.For<ICommitGitVersionControlAction>();
            var fetchAction = Substitute.For<IFetchGitVersionControlAction>();
            var pushAction = Substitute.For<IPushGitVersionControlAction>();
            IGitVersionControl gitVersionControl = new GitVersionControl(branchAction, commitAction, fetchAction, pushAction);
            string commitMessage = "message";

            //Act
            gitVersionControl.Commit(commitMessage);

            //Assert
            commitAction.Received(1).Commit(commitMessage);
        }

        [Fact]
        public void ShouldFetchUsingBranchAction() {
            //Arrange
            var branchAction = Substitute.For<IBranchGitVersionControlAction>();
            var commitAction = Substitute.For<ICommitGitVersionControlAction>();
            var fetchAction = Substitute.For<IFetchGitVersionControlAction>();
            var pushAction = Substitute.For<IPushGitVersionControlAction>();
            IGitVersionControl gitVersionControl = new GitVersionControl(branchAction, commitAction, fetchAction, pushAction);

            //Act
            gitVersionControl.Fetch();

            //Assert
            fetchAction.Received(1).Fetch();
        }

        [Fact]
        public void ShouldPushUsingBranchAction() {
            //Arrange
            var branchAction = Substitute.For<IBranchGitVersionControlAction>();
            var commitAction = Substitute.For<ICommitGitVersionControlAction>();
            var fetchAction = Substitute.For<IFetchGitVersionControlAction>();
            var pushAction = Substitute.For<IPushGitVersionControlAction>();
            IGitVersionControl gitVersionControl = new GitVersionControl(branchAction, commitAction, fetchAction, pushAction);

            //Act
            gitVersionControl.Push();

            //Assert
            pushAction.Received(1).Push();
        }
    }
}
