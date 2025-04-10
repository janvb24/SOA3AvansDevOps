﻿using AvansDevops.DevOps;
using AvansDevops.Notifications;
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
        sprint.sprintState = new DoingSprintState(sprint);

        // Act
        sprint.StartSprint();
        
        // Assert
        Assert.Equivalent(sprint.sprintState, new DoingSprintState(sprint));
    }

    [Fact]
    public void ShouldFinishSprint()
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
        sprint.sprintState = new DoingSprintState(sprint);

        // Act
        sprint.FinishSprint();
        
        // Assert
        Assert.Equivalent(sprint.sprintState, new FinishedSprintState(sprint));
    }
    
    [Fact]
    public void ShouldNotCloseSprint()
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
        sprint.sprintState = new DoingSprintState(sprint);

        // Act
        sprint.CloseSprint(true);
        
        // Assert
        Assert.Equivalent(sprint.sprintState, new DoingSprintState(sprint));
    }
    
    private class SprintMock(Project project, User scrumMaster, Pipeline pipeline, string name)
        : Sprint(project, scrumMaster, pipeline, name);
}