using AvansDevops.DevOps;
using AvansDevops.DevOps.DeployActions;
using AvansDevops.DevOps.TestActions;
using AvansDevops.Notifications;
using AvansDevops.ProjectManagementSystem;
using AvansDevops.ProjectManagementSystem.sprint;
using AvansDevops.SoftwareConfigurationManagement;

namespace AvansDevopsTests.ProjectManagementSystem.sprint;

public class ReleaseSprintTests
{
    [Fact]
    public void ShouldCreateWhenLastActionIsDeployAction()
    {
        // Arrange
        var git = Substitute.For<IGitVersionControl>();
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(git, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
        var scrumMaster = new User("", "", "");
        var pipeline = Substitute.For<Pipeline>();
        var deployAction = Substitute.For<DeployAction>("url");
        pipeline.GetActions().Returns([deployAction]);

        // Act
        var result = new ReleaseSprint(project, scrumMaster, pipeline, "name");

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void ShouldNotCreateWhenLastActionIsNotDeployAction()
    {
        // Arrange
        var git = Substitute.For<IGitVersionControl>();
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(git, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
        var scrumMaster = new User("", "", "");
        var pipeline = Substitute.For<Pipeline>();
        var testAction = Substitute.For<TestAction>();
        pipeline.GetActions().Returns([testAction]);

        // Assert
        Assert.Throws<ArgumentException>(() => new ReleaseSprint(project, scrumMaster, pipeline, "name"));
    }
}