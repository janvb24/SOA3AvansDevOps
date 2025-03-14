using AvansDevops.DevOps;
using AvansDevops.Notifications;

namespace AvansDevopsTests.DevOps;

public class ConcretePipelineBuilderTests
{
    [Fact]
    public void ShouldBuildPipeline()
    {
        // Arrange
        IPipelineBuilder pipelineBuilder = new ConcretePipelineBuilder();
        var expected = new Pipeline(new NotificationService());
        
        // Act
        var result = pipelineBuilder.Build();

        // Assert
        Assert.Equivalent(expected, result);
    }
}