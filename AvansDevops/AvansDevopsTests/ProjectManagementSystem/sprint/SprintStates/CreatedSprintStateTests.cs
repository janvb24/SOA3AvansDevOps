using AvansDevops.DevOps;
using AvansDevops.Notifications;
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
        List<User> developers = [new("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(git, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
        var scrumMaster = new User("", "", "");
        var pipeline = Substitute.For<Pipeline>();
        var sprint = new SprintMock(project, scrumMaster, pipeline, "")
        {
            endDateTime = DateTime.Now.AddDays(14)
        };
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
        List<User> developers = [new("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(git, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
        var scrumMaster = new User("", "", "");
        var pipeline = Substitute.For<Pipeline>();
        var sprint = new SprintMock(project, scrumMaster, pipeline, "")
        {
            endDateTime = DateTime.Now.AddDays(-1)
        };

        // Assert
        Assert.Throws<ArgumentException>(() => sprint.StartSprint());
    }
    
    [Fact]
    public void StartSprintShouldNotStartSprintWhenEndDateTimeIsNotInTheFuture()
    {
        // Arrange
        var git = Substitute.For<IGitVersionControl>();
        List<User> developers = [new("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(git, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
        var scrumMaster = new User("", "", "");
        var pipeline = Substitute.For<Pipeline>();
        var sprint = new SprintMock(project, scrumMaster, pipeline, "")
        {
            endDateTime = DateTime.Now.AddDays(-1)
        };
        var backlogItem = new EditableBacklogItem("", 0, null, tester, scrumMaster);
        sprint.AddToBacklog(backlogItem);

        // Assert
        Assert.Throws<ArgumentException>(() => sprint.StartSprint());
    }

    [Fact]
    public void FinishSprintShouldNotFinishSprint()
    {
        // Arrange
        var git = Substitute.For<IGitVersionControl>();
        List<User> developers = [new("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(git, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
        var scrumMaster = new User("", "", "");
        var pipeline = Substitute.For<Pipeline>();
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
        List<User> developers = [new("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(git, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
        var scrumMaster = new User("", "", "");
        var pipeline = Substitute.For<Pipeline>();
        var sprint = new SprintMock(project, scrumMaster, pipeline, "");

        // Act
        sprint.CloseSprint(true);
        
        // Assert
        Assert.Equivalent(sprint.sprintState, new CreatedSprintState(sprint));
    }
    
    private class SprintMock(Project project, User scrumMaster, Pipeline pipeline, string name)
        : Sprint(project, scrumMaster, pipeline, name);
}