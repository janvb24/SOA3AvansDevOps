using AvansDevops.DevOps;
using AvansDevops.DevOps.DeployActions;
using AvansDevops.DevOps.TestActions;
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
        var leadDev = new User("", "", "");
        var project = new Project(git, leadDev);
        var user = new User("name", "email", "phoneNumber");
        var pipeline = Substitute.For<IPipeline>();
        var deployAction = Substitute.For<DeployAction>("url");
        pipeline.GetActions().Returns([deployAction]);

        // Act
        var result = new ReleaseSprint(project, user, pipeline, "name");

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void ShouldNotCreateWhenLastActionIsNotDeployAction()
    {
        // Arrange
        var git = Substitute.For<IGitVersionControl>();
        var leadDev = new User("", "", "");
        var project = new Project(git, leadDev);
        var user = new User("name", "email", "phoneNumber");
        var pipeline = Substitute.For<IPipeline>();
        var testAction = Substitute.For<TestAction>();
        pipeline.GetActions().Returns([testAction]);

        // Assert
        Assert.Throws<ArgumentException>(() => new ReleaseSprint(project, user, pipeline, "name"));
    }
}