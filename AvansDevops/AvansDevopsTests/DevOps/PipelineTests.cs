using AvansDevops.DevOps;
using AvansDevops.Notifications;

namespace AvansDevopsTests.DevOps;

public class PipelineTests
{
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
        visitor.Received(1).VisitPipeline(pipeline);
        Assert.False(result);
    }
    
    [Fact]
    public void ShouldReturnTrueWhenActionSucceeded()
    {
        // Arrange
        var pipeline = new Pipeline(new NotificationService());
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
}