using AvansDevops.DevOps;
using AvansDevops.ProjectManagementSystem;
using AvansDevops.ProjectManagementSystem.sprint;
using AvansDevops.ProjectManagementSystem.sprint.SprintStates;
using AvansDevops.SoftwareConfigurationManagement;

namespace AvansDevopsTests.ProjectManagementSystem.sprint.SprintStates;

public class DoingSprintStateTests
{
    [Fact]
    public void ShouldNotStartSprintAgain()
    {
        // Arrange
        var git = Substitute.For<IGitVersionControl>();
        var project = new Project(git);
        var user = new User("", "", "");
        var pipeline = Substitute.For<IPipeline>();
        var sprint = new SprintMock(project, user, pipeline, "");
        sprint.sprintState = new DoingSprintState(sprint);

        // Act
        sprint.StartSprint();
        
        // Assert
        Assert.Equivalent(sprint.sprintState, new DoingSprintState(sprint));
    }
    
    [Fact]
    public void ShouldNotCloseSprint()
    {
        // Arrange
        var git = Substitute.For<IGitVersionControl>();
        var project = new Project(git);
        var user = new User("", "", "");
        var pipeline = Substitute.For<IPipeline>();
        var sprint = new SprintMock(project, user, pipeline, "");
        sprint.sprintState = new DoingSprintState(sprint);

        // Act
        sprint.CloseSprint();
        
        // Assert
        Assert.Equivalent(sprint.sprintState, new DoingSprintState(sprint));
    }
    
    private class SprintMock : Sprint
    {
        public SprintMock(Project project, User scrumMaster, IPipeline pipeline, string name) : 
            base(project, scrumMaster, pipeline, name)
        {
        }
    }
}