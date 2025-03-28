using AvansDevops.DevOps;
using AvansDevops.DevOps.BuildActions;
using AvansDevops.DevOps.PackageActions;
using AvansDevops.DevOps.TestActions;
using AvansDevops.Notifications;

namespace AvansDevopsTests.DevOps;

public class PipelineTests
{
    [Fact]
    public void ShouldReturnFalseWhenActionFailed()
    {
        // Arrange
        var notificationService = Substitute.For<INotificationService>();
        var pipeline = new ConcretePipeline(notificationService);
        var visitor = Substitute.For<IPipelineVisitor>();
        var failedAction = Substitute.For<Component>();
        failedAction.Accept(visitor).Returns(false);
        pipeline.Add(failedAction);
        
        // Act
        var result = pipeline.Accept(visitor);
        
        // Assert
        visitor.Received(1).VisitPipeline(pipeline);
        Assert.False(result);
    }
    
    [Fact]
    public void ShouldReturnTrueWhenActionSucceeded()
    {
        // Arrange
        var notificationService = Substitute.For<INotificationService>();
        var pipeline = new ConcretePipeline(notificationService);
        var visitor = Substitute.For<IPipelineVisitor>();
        var succeededAction = Substitute.For<Component>();
        succeededAction.Accept(visitor).Returns(true);
        pipeline.Add(succeededAction);
        
        // Act
        var result = pipeline.Accept(visitor);
        
        // Assert
        visitor.Received(1).VisitPipeline(pipeline);
        Assert.True(result);
    }

    [Fact]
    public void ShouldReturnListOfActions()
    {
        // Arrange
        var notificationService = Substitute.For<INotificationService>();
        var pipeline = new ConcretePipeline(notificationService);
        var testAction = Substitute.For<TestAction>();
        var buildAction = Substitute.For<BuildAction>();
        pipeline.Add(testAction);
        pipeline.Add(buildAction);
        List<Component> expected = [testAction, buildAction];

        // Act
        var results = pipeline.GetActions();

        // Assert
        Assert.Equivalent(expected, results, true);
    }
}