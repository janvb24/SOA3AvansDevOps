using AvansDevops.DevOps;
using AvansDevops.Notifications;
using AvansDevops.ProjectManagementSystem.sprint.SprintStates;
using AvansDevops.ProjectManagementSystem;
using AvansDevops.SoftwareConfigurationManagement;
using AvansDevopsTests.ProjectManagementSystem.report;
using AvansDevops.ProjectManagementSystem.sprint;
using AvansDevops.DevOps.DeployActions;

namespace AvansDevopsTests.ProjectManagementSystem.sprint.SprintStates {
    public class FinishedSprintStateTests {
        [Fact]
        public void StartSprintShouldDoNothing() {
            // Arrange
            var git = Substitute.For<IGitVersionControl>();
            List<User> developers = [new User("", "", "")];
            var tester = new User("", "", "");
            var leadDev = new User("", "", "");
            var productOwner = new User("", "", "");
            var project = new Project(git, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
            var scrumMaster = new User("", "", "");
            var pipeline = Substitute.For<Pipeline>();
            var sprint = new SprintMock(project, scrumMaster, pipeline, "");
            sprint.sprintState = new FinishedSprintState(sprint);    

            // Act
            sprint.StartSprint();

            // Assert
            Assert.Equivalent(sprint.sprintState, new FinishedSprintState(sprint));
            Assert.False(sprint.approved);
        }

        [Fact]
        public void FinishSprintShouldDoNothing() {
            // Arrange
            var git = Substitute.For<IGitVersionControl>();
            List<User> developers = [new User("", "", "")];
            var tester = new User("", "", "");
            var leadDev = new User("", "", "");
            var productOwner = new User("", "", "");
            var project = new Project(git, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
            var scrumMaster = new User("", "", "");
            var pipeline = Substitute.For<Pipeline>();
            var sprint = new SprintMock(project, scrumMaster, pipeline, "");
            sprint.sprintState = new FinishedSprintState(sprint);

            // Act
            sprint.FinishSprint();

            // Assert
            Assert.Equivalent(sprint.sprintState, new FinishedSprintState(sprint));
            Assert.False(sprint.approved);
        }

        [Fact]
        public void CloseSprintShouldRunPipelineIfApproveAndIfReleaseSprint() {
            // Arrange
            var git = Substitute.For<IGitVersionControl>();
            List<User> developers = [new User("", "", "")];
            var tester = new User("", "", "");
            var leadDev = new User("", "", "");
            var productOwner = new User("", "", "");
            var project = new Project(git, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
            var scrumMaster = new User("", "", "");
            var pipeline = Substitute.For<Pipeline>();
            pipeline.GetActions().Returns([new AzureDeployAction("test")]);
            pipeline.Accept(Arg.Any<RunPipelineVisitor>()).Returns(true);
            var sprint = new ReleaseSprint(project, scrumMaster, pipeline, "");
            sprint.sprintState = new FinishedSprintState(sprint);

            // Act
            sprint.CloseSprint(true);

            // Assert
            pipeline.Received().Accept(Arg.Any<RunPipelineVisitor>());
            Assert.Equivalent(sprint.sprintState, new ClosedSprintState());
            Assert.True(sprint.approved);
        }

        [Fact]
        public void CloseSprintShouldRunPipelineIfApproveAndIfReleaseSprintWithPipelineFaile() {
            // Arrange
            var git = Substitute.For<IGitVersionControl>();
            List<User> developers = [new User("", "", "")];
            var tester = new User("", "", "");
            var leadDev = new User("", "", "");
            var productOwner = new User("", "", "");
            var project = new Project(git, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
            var scrumMaster = new User("", "", "");
            var pipeline = Substitute.For<Pipeline>();
            pipeline.GetActions().Returns([new AzureDeployAction("test")]);
            pipeline.Accept(Arg.Any<RunPipelineVisitor>()).Returns(false);
            var sprint = new ReleaseSprint(project, scrumMaster, pipeline, "");
            sprint.sprintState = new FinishedSprintState(sprint);

            // Act
            sprint.CloseSprint(true);

            // Assert
            pipeline.Received().Accept(Arg.Any<RunPipelineVisitor>());
            Assert.Equivalent(sprint.sprintState, new FinishedSprintState(sprint));
            Assert.False(sprint.approved);
        }

        [Fact]
        public void CloseSprintShouldCloseIfApproveAndReviewSprint() {
            // Arrange
            var git = Substitute.For<IGitVersionControl>();
            List<User> developers = [new User("", "", "")];
            var tester = new User("", "", "");
            var leadDev = new User("", "", "");
            var productOwner = new User("", "", "");
            var project = new Project(git, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
            var scrumMaster = new User("", "", "");
            var pipeline = Substitute.For<Pipeline>();
            pipeline.Accept(Arg.Any<RunPipelineVisitor>()).Returns(true);
            var sprint = new ReviewSprint(project, scrumMaster, pipeline, "");
            sprint.sprintState = new FinishedSprintState(sprint);

            // Act
            sprint.CloseSprint(true);

            // Assert
            pipeline.DidNotReceive().Accept(Arg.Any<RunPipelineVisitor>());
            Assert.Equivalent(sprint.sprintState, new ClosedSprintState());
            Assert.True(sprint.approved);
        }

        [Fact]
        public void CloseSprintShouldSendMessageIfNotApprove() {
            // Arrange
            var git = Substitute.For<IGitVersionControl>();
            List<User> developers = [new User("", "", "")];
            var tester = new User("", "", "");
            var leadDev = new User("", "", "");
            var productOwner = new User("", "", "");
            var notificationService = Substitute.For<INotificationService>();
            var project = new Project(git, developers, tester, leadDev, productOwner, notificationService);
            var scrumMaster = new User("", "", "");
            var pipeline = Substitute.For<Pipeline>();
            pipeline.Accept(Arg.Any<RunPipelineVisitor>()).Returns(true);
            var sprint = new ReviewSprint(project, scrumMaster, pipeline, "");
            sprint.sprintState = new FinishedSprintState(sprint);

            // Act
            sprint.CloseSprint(false);

            // Assert
            pipeline.DidNotReceive().Accept(Arg.Any<RunPipelineVisitor>());
            notificationService.Received().Send(Arg.Is<List<User>>(x => x.Contains(sprint.project.productOwner) && x.Contains(sprint.scrumMaster)), "Sprint has not been approved");
            Assert.Equivalent(sprint.sprintState, new ClosedSprintState());
            Assert.False(sprint.approved);
        }
    }
}
