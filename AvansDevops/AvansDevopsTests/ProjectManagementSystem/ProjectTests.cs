using AvansDevops.DevOps;
using AvansDevops.DevOps.DeployActions;
using AvansDevops.ProjectManagementSystem;
using AvansDevops.ProjectManagementSystem.sprint;
using AvansDevops.SoftwareConfigurationManagement;

namespace AvansDevopsTests.ProjectManagementSystem;

public class ProjectTests
{
    [Fact]
    public void AddDeveloperShouldAddANewDeveloper()
    {
        // Arrange
        var gitVersionControl = Substitute.For<IGitVersionControl>();
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(gitVersionControl, developers, tester, leadDev, productOwner);
        var newDeveloper = new User("", "", "");
        List<User> expected = [developers[0], newDeveloper];

        // Act
        project.AddDeveloper(newDeveloper);
        
        // Assert
        Assert.Equivalent(project.developers, expected, true);
    }

    [Fact]
    public void RemoveDeveloperShouldRemoveAnExistingDeveloper()
    {
        // Arrange
        var gitVersionControl = Substitute.For<IGitVersionControl>();
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(gitVersionControl, developers, tester, leadDev, productOwner);
        var newDeveloper = new User("", "", "");
        project.AddDeveloper(newDeveloper);
        List<User> expected = [developers[0]];
        
        // Act
        project.RemoveDeveloper(newDeveloper);
        
        // Assert
        Assert.Equivalent(project.developers, expected, true);
    }
    
    [Fact]
    public void RemoveDeveloperShouldNotRemoveLastDeveloper()
    {
        // Arrange
        var gitVersionControl = Substitute.For<IGitVersionControl>();
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(gitVersionControl, developers, tester, leadDev, productOwner);
        
        // Assert
        Assert.Throws<ArgumentException>(() => project.RemoveDeveloper(developers[0]));
    }
    
    [Fact]
    public void RemoveDeveloperShouldNotRemoveNotExistingDeveloper()
    {
        // Arrange
        var gitVersionControl = Substitute.For<IGitVersionControl>();
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(gitVersionControl, developers, tester, leadDev, productOwner);
        var notExistingDeveloper = new User("", "", "");
        
        // Assert
        Assert.Throws<ArgumentException>(() => project.RemoveDeveloper(notExistingDeveloper));
    }
    
    [Fact]
    public void NewSprintShouldCreateReleaseSprint()
    {
        // Arrange
        var gitVersionControl = Substitute.For<IGitVersionControl>();
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(gitVersionControl, developers, tester, leadDev, productOwner);
        var scrumMaster = new User("name", "email@server.com", "0612345678");
        var pipeline = Substitute.For<IPipeline>();
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
    public void NewSprintShouldCreateReviewSprint()
    {
        // Arrange
        var gitVersionControl = Substitute.For<IGitVersionControl>();
        List<User> developers = [new User("", "", "")];
        var tester = new User("", "", "");
        var leadDev = new User("", "", "");
        var productOwner = new User("", "", "");
        var project = new Project(gitVersionControl, developers, tester, leadDev, productOwner);
        var scrumMaster = new User("name", "email@server.com", "0612345678");
        var pipeline = Substitute.For<IPipeline>();
        var expected = new ReviewSprint(project, scrumMaster, pipeline, "New sprint");

        // Act
        project.NewSprint(scrumMaster, pipeline, "New sprint", SprintType.REVIEW_SPRINT);
        var result = project.currentSprint;

        // Assert
        Assert.Equivalent(expected, result, true);
    }
}