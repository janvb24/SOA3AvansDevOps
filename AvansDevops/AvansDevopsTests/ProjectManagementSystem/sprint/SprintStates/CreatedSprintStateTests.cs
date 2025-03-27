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
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(git, developers, tester, leadDev, productOwner);
        var scrumMaster = new User("", "", "");
        var pipeline = Substitute.For<IPipeline>();
        var sprint = new SprintMock(project, scrumMaster, pipeline, "");
        var backlogItem = new EditableBacklogItem("", 0, null, tester, scrumMaster);
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
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(git, developers, tester, leadDev, productOwner);
        var scrumMaster = new User("", "", "");
        var pipeline = Substitute.For<IPipeline>();
        var sprint = new SprintMock(project, scrumMaster, pipeline, "");

        // Assert
        Assert.Throws<ArgumentException>(() => sprint.StartSprint());
    }

    [Fact]
    public void FinishSprintShouldNotFinishSprint()
    {
        // Arrange
        var git = Substitute.For<IGitVersionControl>();
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(git, developers, tester, leadDev, productOwner);
        var scrumMaster = new User("", "", "");
        var pipeline = Substitute.For<IPipeline>();
        var sprint = new SprintMock(project, scrumMaster, pipeline, "");

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
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(git, developers, tester, leadDev, productOwner);
        var scrumMaster = new User("", "", "");
        var pipeline = Substitute.For<IPipeline>();
        var sprint = new SprintMock(project, scrumMaster, pipeline, "");

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