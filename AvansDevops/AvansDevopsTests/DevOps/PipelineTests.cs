using AvansDevops.DevOps;
using AvansDevops.Notifications;

namespace AvansDevopsTests.DevOps;

public class PipelineTests
{
    [Fact]
    public void ShouldAcceptVisitor()
    {
        // Arrange
        var pipeline = new Pipeline(new NotificationService());
        var visitor = Substitute.For<IPipelineVisitor>();
        
        // Act
        pipeline.Accept(visitor);
        
        // Assert
        visitor.Received(1).VisitPipeline(pipeline);
    }

    [Fact]
    public void ShouldReturnFalseWhenActionFailed()
    {
        // Arrange
        var pipeline = new Pipeline(new NotificationService());
        var visitor = Substitute.For<IPipelineVisitor>();
        var failedAction = Substitute.For<Component>();
        failedAction.Accept(visitor).Returns(false);
        pipeline.Add(failedAction);
        
        // Act
        var result = pipeline.Accept(visitor);
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void ShouldReturnTrueWhenActionSucceeded()
    {
        // Arrange
        var pipeline = new Pipeline(new NotificationService());
        var visitor = Substitute.For<IPipelineVisitor>();
        var failedAction = Substitute.For<Component>();
        failedAction.Accept(visitor).Returns(true);
        pipeline.Add(failedAction);
        
        // Act
        var result = pipeline.Accept(visitor);
        
        // Assert
        Assert.True(result);
    }
}