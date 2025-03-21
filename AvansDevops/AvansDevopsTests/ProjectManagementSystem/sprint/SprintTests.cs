﻿using AvansDevops.DevOps;
using AvansDevops.ProjectManagementSystem;
using AvansDevops.ProjectManagementSystem.backlog;
using AvansDevops.ProjectManagementSystem.sprint;
using AvansDevops.SoftwareConfigurationManagement;

namespace AvansDevopsTests.ProjectManagementSystem.sprint;

public class SprintTests
{
    [Fact]
    public void NameShouldBeEditableWhenEditableIsTrue()
    {
        // Arrange
        IGitVersionControl git = Substitute.For<IGitVersionControl>();
        var leadDev = new User("", "", "");
        var project = new Project(git, leadDev);
        User scrumMaster = new User("", "", "");
        IPipeline pipeline = Substitute.For<IPipeline>();
        Sprint sprint = new SprintMock(project, scrumMaster, pipeline, "");
        sprint.editable = true;
        
        // Act
        sprint.name = "editedName";
        
        // Assert
        Assert.Equal("editedName", sprint.name);
    }
    
    [Fact]
    public void NameShouldNotBeEditableWhenEditableIsFalse()
    {
        // Arrange
        IGitVersionControl git = Substitute.For<IGitVersionControl>();
        var leadDev = new User("", "", "");
        var project = new Project(git, leadDev);
        User scrumMaster = new User("", "", "");
        IPipeline pipeline = Substitute.For<IPipeline>();
        Sprint sprint = new SprintMock(project, scrumMaster, pipeline, "");
        sprint.editable = false;

        // Assert
        Assert.Throws<ArgumentException>(() => sprint.name = "editedName");
    }
    
    [Fact]
    public void EndDateTimeShouldBeEditableWhenEditableIsTrue()
    {
        // Arrange
        IGitVersionControl git = Substitute.For<IGitVersionControl>();
        var leadDev = new User("", "", "");
        var project = new Project(git, leadDev);
        User scrumMaster = new User("", "", "");
        IPipeline pipeline = Substitute.For<IPipeline>();
        Sprint sprint = new SprintMock(project, scrumMaster, pipeline, "");
        sprint.editable = true;
        
        // Act
        sprint.endDateTime = new DateTime();
        
        // Assert
        Assert.Equal(new DateTime(), sprint.endDateTime);
    }
    
    [Fact]
    public void EndDateTimeShouldNotBeEditableWhenEditableIsFalse()
    {
        // Arrange
        IGitVersionControl git = Substitute.For<IGitVersionControl>();
        var leadDev = new User("", "", "");
        var project = new Project(git, leadDev);
        User scrumMaster = new User("", "", "");
        IPipeline pipeline = Substitute.For<IPipeline>();
        Sprint sprint = new SprintMock(project, scrumMaster, pipeline, "");
        sprint.editable = false;

        // Assert
        Assert.Throws<ArgumentException>(() => sprint.endDateTime = new DateTime());
    }
    
    [Fact]
    public void ProjectShouldBeEditableWhenEditableIsTrue()
    {
        // Arrange
        IGitVersionControl git = Substitute.For<IGitVersionControl>();
        var leadDev = new User("", "", "");
        var project = new Project(git, leadDev);
        User scrumMaster = new User("", "", "");
        IPipeline pipeline = Substitute.For<IPipeline>();
        Sprint sprint = new SprintMock(project, scrumMaster, pipeline, "");
        sprint.editable = true;
        
        // Act
        sprint.project = new Project(git, leadDev);
        
        // Assert
        Assert.Equivalent(new Project(git, leadDev), sprint.project, true);
    }
    
    [Fact]
    public void ProjectShouldNotBeEditableWhenEditableIsFalse()
    {
        // Arrange
        IGitVersionControl git = Substitute.For<IGitVersionControl>();
        var leadDev = new User("", "", "");
        var project = new Project(git, leadDev);
        User scrumMaster = new User("", "", "");
        IPipeline pipeline = Substitute.For<IPipeline>();
        Sprint sprint = new SprintMock(project, scrumMaster, pipeline, "");
        sprint.editable = false;

        // Assert
        Assert.Throws<ArgumentException>(() => sprint.project = new Project(git, leadDev));
    }
    
    [Fact]
    public void BacklogShouldBeEditableWhenEditableIsTrue()
    {
        // Arrange
        IGitVersionControl git = Substitute.For<IGitVersionControl>();
        var leadDev = new User("", "", "");
        var project = new Project(git, leadDev);
        var scrumMaster = new User("", "", "");
        var tester = new User("", "", "");
        IPipeline pipeline = Substitute.For<IPipeline>();
        BacklogItem backlogItem = new BacklogItemMock("", 0, tester, scrumMaster);
        Sprint sprint = new SprintMock(project, scrumMaster, pipeline, "");
        sprint.editable = true;
        
        // Act
        sprint.AddToBacklog(backlogItem);
        var result = sprint.GetBacklogItems();
        
        // Assert
        Assert.Equal(backlogItem, result[0]);
    }
    
    [Fact]
    public void BacklogShouldNotBeEditableWhenEditableIsFalse()
    {
        // Arrange
        IGitVersionControl git = Substitute.For<IGitVersionControl>();
        var leadDev = new User("", "", "");
        var project = new Project(git, leadDev);
        var scrumMaster = new User("", "", "");
        var tester = new User("", "", "");
        IPipeline pipeline = Substitute.For<IPipeline>();
        BacklogItem backlogItem = new BacklogItemMock("", 0, tester, scrumMaster);
        Sprint sprint = new SprintMock(project, scrumMaster, pipeline, "");
        sprint.editable = false;
        
        // Assert
        Assert.Throws<ArgumentException>(() => sprint.AddToBacklog(backlogItem));
    }
    
    [Fact]
    public void ScrumMasterShouldBeEditableWhenEditableIsTrue()
    {
        // Arrange
        IGitVersionControl git = Substitute.For<IGitVersionControl>();
        var leadDev = new User("", "", "");
        var project = new Project(git, leadDev);
        User scrumMaster = new User("", "", "");
        IPipeline pipeline = Substitute.For<IPipeline>();
        Sprint sprint = new SprintMock(project, scrumMaster, pipeline, "");
        sprint.editable = true;
        
        // Act
        sprint.scrumMaster = new User("", "", "");
        
        // Assert
        Assert.Equivalent(new User("", "", ""), sprint.scrumMaster, true);
    }
    
    [Fact]
    public void ScrumMasterShouldNotBeEditableWhenEditableIsFalse()
    {
        // Arrange
        IGitVersionControl git = Substitute.For<IGitVersionControl>();
        var leadDev = new User("", "", "");
        var project = new Project(git, leadDev);
        User scrumMaster = new User("", "", "");
        IPipeline pipeline = Substitute.For<IPipeline>();
        Sprint sprint = new SprintMock(project, scrumMaster, pipeline, "");
        sprint.editable = false;

        // Assert
        Assert.Throws<ArgumentException>(() => sprint.scrumMaster = new User("", "", ""));
    }
    
    [Fact]
    public void PipelineShouldBeEditableWhenEditableIsTrue()
    {
        // Arrange
        IGitVersionControl git = Substitute.For<IGitVersionControl>();
        var leadDev = new User("", "", "");
        var project = new Project(git, leadDev);
        User scrumMaster = new User("", "", "");
        IPipeline pipeline = Substitute.For<IPipeline>();
        Sprint sprint = new SprintMock(project, scrumMaster, pipeline, "");
        sprint.editable = true;
        
        // Act
        sprint.pipeline = Substitute.For<IPipeline>();
        
        // Assert
        Assert.Equivalent(sprint.pipeline, Substitute.For<IPipeline>(), true);
    }
    
    [Fact]
    public void PipelineShouldNotBeEditableWhenEditableIsFalse()
    {
        // Arrange
        IGitVersionControl git = Substitute.For<IGitVersionControl>();
        var leadDev = new User("", "", "");
        var project = new Project(git, leadDev);
        User scrumMaster = new User("", "", "");
        IPipeline pipeline = Substitute.For<IPipeline>();
        Sprint sprint = new SprintMock(project, scrumMaster, pipeline, "");
        sprint.editable = false;

        // Assert
        Assert.Throws<ArgumentException>(() => sprint.pipeline = Substitute.For<IPipeline>());
    }

    [Fact]
    public void ShouldNotAddSubtaskToBacklog()
    {
        // Arrange
        IGitVersionControl git = Substitute.For<IGitVersionControl>();
        var leadDev = new User("", "", "");
        var project = new Project(git, leadDev);
        var scrumMaster = new User("", "", "");
        var tester = new User("", "", "");
        IPipeline pipeline = Substitute.For<IPipeline>();
        Sprint sprint = new SprintMock(project, scrumMaster, pipeline, "");
        BacklogItem parentBacklogItem = new BacklogItemMock("", 0, tester, scrumMaster);
        BacklogItem childBacklogItem = new BacklogItemMock("", 0, tester, scrumMaster, parent: parentBacklogItem);
        
        // Assert
        Assert.Throws<ArgumentException>(() => sprint.AddToBacklog(childBacklogItem));
    }

    [Fact]
    public void ShouldAddBacklogItemToBacklog()
    {
        // Arrange
        IGitVersionControl git = Substitute.For<IGitVersionControl>();
        var leadDev = new User("", "", "");
        var project = new Project(git, leadDev);
        var scrumMaster = new User("", "", "");
        var tester = new User("", "", "");
        IPipeline pipeline = Substitute.For<IPipeline>();
        Sprint sprint = new SprintMock(project, scrumMaster, pipeline, "");
        BacklogItem backlogItem = new BacklogItemMock("", 0, tester, scrumMaster);
        
        // Act
        sprint.AddToBacklog(backlogItem);
        var result = sprint.GetBacklogItems();
        
        // Assert
        Assert.Equal(backlogItem, result[0]);
    }

    [Fact]
    public void ShouldReturnBacklogItems()
    {
        // Arrange
        IGitVersionControl git = Substitute.For<IGitVersionControl>();
        var leadDev = new User("", "", "");
        var project = new Project(git, leadDev);
        var scrumMaster = new User("", "", "");
        var tester = new User("", "", "");
        IPipeline pipeline = Substitute.For<IPipeline>();
        Sprint sprint = new SprintMock(project, scrumMaster, pipeline, "");
        BacklogItem backlogItem1 = new BacklogItemMock("", 0, tester, scrumMaster);
        BacklogItem backlogItem2 = new BacklogItemMock("", 0, tester, scrumMaster);
        BacklogItem backlogItem3 = new BacklogItemMock("", 0, tester, scrumMaster);
        List<BacklogItem> expected = [backlogItem1, backlogItem2, backlogItem3]; 
        
        // Act
        sprint.AddToBacklog(backlogItem1);
        sprint.AddToBacklog(backlogItem2);
        sprint.AddToBacklog(backlogItem3);
        var result = sprint.GetBacklogItems();
        
        // Arrange
        Assert.Equivalent(expected, result, true);
    }
    
    private class SprintMock : Sprint
    {
        public SprintMock(Project project, User scrumMaster, IPipeline pipeline, string name) : 
            base(project, scrumMaster, pipeline, name)
        {
        }
    }

    private class BacklogItemMock : BacklogItem
    {
        public BacklogItemMock(string title, int storyPoints, User tester, User scrumMaster, User? developer = null, List<BacklogItem>? subTasks = null, BacklogItem? parent = null) : 
            base(title, storyPoints, developer, tester, scrumMaster, subTasks, parent)
        {
        }
    }
}
