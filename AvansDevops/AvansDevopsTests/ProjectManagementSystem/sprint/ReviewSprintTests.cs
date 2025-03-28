using AvansDevops.DevOps;
using AvansDevops.DevOps.DeployActions;
using AvansDevops.Notifications;
using AvansDevops.ProjectManagementSystem;
using AvansDevops.ProjectManagementSystem.sprint;
using AvansDevops.ProjectManagementSystem.sprint.SprintStates;
using AvansDevops.SoftwareConfigurationManagement;

namespace AvansDevopsTests.ProjectManagementSystem.sprint;

public class ReviewSprintTests
{
    [Fact]
    public void ShouldNotSaveSummaryBecauseFileIsNotAPdf()
    {
        // Arrange
        var git = Substitute.For<IGitVersionControl>();
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(git, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
        var scrumMaster = new User("", "", "");
        var sprint = new ReviewSprint(project, scrumMaster, null, "myReviewSprint");
        sprint.sprintState = new FinishedSprintState(sprint);
        
        // Assert
        Assert.Throws<FileLoadException>(() => sprint.SaveSummaryPdf(@"file\location\to\store\a.txt"));
    }
    
    [Fact]
    public void ShouldSaveSummary()
    {
        // Arrange
        var git = Substitute.For<IGitVersionControl>();
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(git, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
        var scrumMaster = new User("", "", "");
        var sprint = new ReviewSprint(project, scrumMaster, null, "myReviewSprint");
        sprint.sprintState = new FinishedSprintState(sprint);
        
        // Act
        sprint.SaveSummaryPdf(@"file\location\to\store\a.pdf");
        
        // Assert
        Assert.True(sprint.summaryAdded);
    }
}