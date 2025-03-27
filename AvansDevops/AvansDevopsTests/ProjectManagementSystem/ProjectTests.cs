using AvansDevops.DevOps;
using AvansDevops.DevOps.DeployActions;
using AvansDevops.Notifications;
using AvansDevops.ProjectManagementSystem;
using AvansDevops.ProjectManagementSystem.backlog;
using AvansDevops.ProjectManagementSystem.sprint;
using AvansDevops.SoftwareConfigurationManagement;

namespace AvansDevopsTests.ProjectManagementSystem;

public class ProjectTests {

    [Fact]
    public void AddDeveloperShouldAddANewDeveloper() {
        // Arrange
        var gitVersionControl = Substitute.For<IGitVersionControl>();
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(gitVersionControl, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
        var newDeveloper = new User("", "", "");
        List<User> expected = [developers[0], newDeveloper];

        // Act
        project.AddDeveloper(newDeveloper);

        // Assert
        Assert.Equivalent(project.developers, expected, true);
    }

    [Fact]
    public void RemoveDeveloperShouldRemoveAnExistingDeveloper() {
        // Arrange
        var gitVersionControl = Substitute.For<IGitVersionControl>();
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", ""); 
        var project = new Project(gitVersionControl, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
        var newDeveloper = new User("", "", "");
        project.AddDeveloper(newDeveloper);
        List<User> expected = [developers[0]];

        // Act
        project.RemoveDeveloper(newDeveloper);

        // Assert
        Assert.Equivalent(project.developers, expected, true);
    }

    [Fact]
    public void RemoveDeveloperShouldNotRemoveLastDeveloper() {
        // Arrange
        var gitVersionControl = Substitute.For<IGitVersionControl>();
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(gitVersionControl, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());

        // Assert
        Assert.Throws<ArgumentException>(() => project.RemoveDeveloper(developers[0]));
    }

    [Fact]
    public void RemoveDeveloperShouldNotRemoveNotExistingDeveloper() {
        // Arrange
        var gitVersionControl = Substitute.For<IGitVersionControl>();
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(gitVersionControl, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
        var notExistingDeveloper = new User("", "", "");

        // Assert
        Assert.Throws<ArgumentException>(() => project.RemoveDeveloper(notExistingDeveloper));
    }

    [Fact]
    public void NewSprintShouldCreateReleaseSprint() {
        // Arrange
        var gitVersionControl = Substitute.For<IGitVersionControl>();
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(gitVersionControl, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
        var scrumMaster = new User("name", "email@server.com", "0612345678");
        var pipeline = Substitute.For<Pipeline>();
        var deployAction = Substitute.For<DeployAction>("deploy.server.com");
        pipeline.GetActions().Returns([deployAction]);
        var expected = new ReleaseSprint(project, scrumMaster, pipeline, "New sprint");

        // Act
        project.NewSprint(scrumMaster, pipeline, "New sprint", SprintType.RELEASE_SPRINT);
        var result = project.currentSprint;

        // Assert
        Assert.Equivalent(expected, result, true);
    }

    [Fact]
    public void NewSprintShouldCreateReviewSprint() {
        // Arrange
        var gitVersionControl = Substitute.For<IGitVersionControl>();
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(gitVersionControl, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
        var scrumMaster = new User("name", "email@server.com", "0612345678");
        var pipeline = Substitute.For<Pipeline>();
        var expected = new ReviewSprint(project, scrumMaster, pipeline, "New sprint");

        // Act
        project.NewSprint(scrumMaster, pipeline, "New sprint", SprintType.REVIEW_SPRINT);
        var result = project.currentSprint;

        // Assert
        Assert.Equivalent(expected, result, true);
    }
    
    [Fact]
    public void MovingAnExistingBacklogItemShouldWork()
    {
        // Arrange
        var gitVersionControl = Substitute.For<IGitVersionControl>();
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(gitVersionControl, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
        var scrumMaster = new User("name", "email@server.com", "0612345678");
        var backlogItem = new BacklogItemMock("backlog item", 0, tester, scrumMaster);
        var pipeline = Substitute.For<Pipeline>();

        // Act
        project.NewSprint(scrumMaster, pipeline, "new sprint", SprintType.REVIEW_SPRINT);
        project.projectBacklog.AddBacklogItem(backlogItem);
        project.MoveBacklogItemToSprint(backlogItem);

        // Assert
        Assert.Empty(project.projectBacklog.GetBacklogItems());
        Assert.Equal(backlogItem, project.currentSprint.GetBacklogItems()[0]);
    }

    [Fact]
    public void MovingANonExistentBacklogItemShouldThrowError()
    {
        // Arrange
        var gitVersionControl = Substitute.For<IGitVersionControl>();
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(gitVersionControl, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
        var scrumMaster = new User("name", "email@server.com", "0612345678");
        var backlogItem = new BacklogItemMock("backlog item", 0, tester, scrumMaster);
        var pipeline = Substitute.For<Pipeline>();
        
        // Act
        project.NewSprint(scrumMaster, pipeline, "new sprint", SprintType.REVIEW_SPRINT);
        
        // Assert
        Assert.Throws<ArgumentException>(() => project.MoveBacklogItemToSprint(backlogItem));
    }

    [Fact]
    public void AddingANonExistentBacklogItemToSprintShouldWork()
    {
        // Arrange
        var gitVersionControl = Substitute.For<IGitVersionControl>();
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(gitVersionControl, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
        var scrumMaster = new User("name", "email@server.com", "0612345678");
        var backlogItem = new BacklogItemMock("backlog item", 0, tester, scrumMaster);
        var pipeline = Substitute.For<Pipeline>();
        
        // Act
        project.NewSprint(scrumMaster, pipeline, "new sprint", SprintType.REVIEW_SPRINT);
        project.AddNewBacklogItemToSprint(backlogItem);
        
        // Assert
        Assert.Equal(backlogItem, project.currentSprint.GetBacklogItems()[0]);
    }
    
    [Fact]
    public void AddingAnExistingBacklogItemToSprintShouldThrowError()
    {
        // Arrange
        var gitVersionControl = Substitute.For<IGitVersionControl>();
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(gitVersionControl, developers, tester, leadDev, productOwner, Substitute.For<INotificationService>());
        var scrumMaster = new User("name", "email@server.com", "0612345678");
        var backlogItem = new BacklogItemMock("backlog item", 0, tester, scrumMaster);
        var pipeline = Substitute.For<Pipeline>();
        
        // Act
        project.projectBacklog.AddBacklogItem(backlogItem);
        project.NewSprint(scrumMaster, pipeline, "new sprint", SprintType.REVIEW_SPRINT);
        
        // Assert
        Assert.Throws<ArgumentException>(() => project.AddNewBacklogItemToSprint(backlogItem));
    }
    
    private class BacklogItemMock(
        string title,
        int storyPoints,
        User tester,
        User scrumMaster,
        User? developer = null,
        List<BacklogItem>? subTasks = null,
        BacklogItem? parent = null)
        : BacklogItem(title, storyPoints, developer, tester, scrumMaster, subTasks, parent);
}