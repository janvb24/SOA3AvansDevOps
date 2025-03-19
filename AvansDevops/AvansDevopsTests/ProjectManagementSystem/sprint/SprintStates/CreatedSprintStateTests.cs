using AvansDevops.DevOps;
using AvansDevops.ProjectManagementSystem;
using AvansDevops.ProjectManagementSystem.backlog;
using AvansDevops.ProjectManagementSystem.sprint;
using AvansDevops.ProjectManagementSystem.sprint.SprintStates;
using AvansDevops.SoftwareConfigurationManagement;

namespace AvansDevopsTests.ProjectManagementSystem.sprint.SprintStates;

public class CreatedSprintStateTests
{
    [Fact]
    public void StartSprintShouldStartSprint()
    {
        // Arrange
        var git = Substitute.For<IGitVersionControl>();
        var project = new Project(git);
        var user = new User("", "", "");
        var pipeline = Substitute.For<IPipeline>();
        var sprint = new SprintMock(project, user, pipeline, "");
        var backlogItem = new EditableBacklogItem("", 0);
        sprint.AddToBacklog(backlogItem);

        // Act
        sprint.StartSprint();
        
        // Assert
        Assert.Equivalent(sprint.sprintState, new DoingSprintState(sprint));
    }
    
    [Fact]
    public void StartSprintShouldNotStartSprintForBacklogIsEmpty()
    {
        // Arrange
        var git = Substitute.For<IGitVersionControl>();
        var project = new Project(git);
        var user = new User("", "", "");
        var pipeline = Substitute.For<IPipeline>();
        var sprint = new SprintMock(project, user, pipeline, "");

        // Assert
        Assert.Throws<ArgumentException>(() => sprint.StartSprint());
    }

    [Fact]
    public void FinishSprintShouldNotFinishSprint()
    {
        // Arrange
        var git = Substitute.For<IGitVersionControl>();
        var project = new Project(git);
        var user = new User("", "", "");
        var pipeline = Substitute.For<IPipeline>();
        var sprint = new SprintMock(project, user, pipeline, "");

        // Act
        sprint.FinishSprint();
        
        // Assert
        Assert.Equivalent(sprint.sprintState, new CreatedSprintState(sprint));
    }
    
    [Fact]
    public void CloseSprintShouldNotFinishSprint()
    {
        // Arrange
        var git = Substitute.For<IGitVersionControl>();
        var project = new Project(git);
        var user = new User("", "", "");
        var pipeline = Substitute.For<IPipeline>();
        var sprint = new SprintMock(project, user, pipeline, "");

        // Act
        sprint.CloseSprint();
        
        // Assert
        Assert.Equivalent(sprint.sprintState, new CreatedSprintState(sprint));
    }
    
    private class SprintMock : Sprint
    {
        public SprintMock(Project project, User scrumMaster, IPipeline pipeline, string name) : 
            base(project, scrumMaster, pipeline, name)
        {
        }
    }
}