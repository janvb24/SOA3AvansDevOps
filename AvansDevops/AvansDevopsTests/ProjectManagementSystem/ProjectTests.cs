using AvansDevops.DevOps;
using AvansDevops.DevOps.DeployActions;
using AvansDevops.ProjectManagementSystem;
using AvansDevops.ProjectManagementSystem.sprint;
using AvansDevops.SoftwareConfigurationManagement;

namespace AvansDevopsTests.ProjectManagementSystem;

public class ProjectTests
{
    [Fact]
    public void NewSprintShouldCreateReleaseSprint()
    {
        // Arrange
        var gitVersionControl = Substitute.For<IGitVersionControl>();
        var leadDev = new User("", "", "");
        var project = new Project(gitVersionControl, leadDev);
        var user = new User("name", "email@server.com", "0612345678");
        var pipeline = Substitute.For<IPipeline>();
        var deployAction = Substitute.For<DeployAction>("deploy.server.com");
        pipeline.GetActions().Returns([deployAction]);
        var expected = new ReleaseSprint(project, user, pipeline, "New sprint");

        // Act
        project.NewSprint(user, pipeline, "New sprint", SprintType.RELEASE_SPRINT);
        var result = project.currentSprint;

        // Assert
        Assert.Equivalent(expected, result, true);
    }
    
    [Fact]
    public void NewSprintShouldCreateReviewSprint()
    {
        // Arrange
        var gitVersionControl = Substitute.For<IGitVersionControl>();
        var leadDev = new User("", "", "");
        var project = new Project(gitVersionControl, leadDev);
        var user = new User("name", "email@server.com", "0612345678");
        var pipeline = Substitute.For<IPipeline>();
        var expected = new ReviewSprint(project, user, pipeline, "New sprint");

        // Act
        project.NewSprint(user, pipeline, "New sprint", SprintType.REVIEW_SPRINT);
        var result = project.currentSprint;

        // Assert
        Assert.Equivalent(expected, result, true);
    }
}