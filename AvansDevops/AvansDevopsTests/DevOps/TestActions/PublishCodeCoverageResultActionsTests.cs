using AvansDevops.DevOps.TestActions;

namespace AvansDevopsTests.DevOps.TestActions;

public class PublishCodeCoverageResultActionsTests
{
    [Fact]
    public void RunTestActionShouldReturnTrue()
    {
        // Arrange
        var action = new PublishCodeCoverageResultAction();

        // Act
        var result = action.RunTestAction();

        // Assert
        Assert.True(result);
    }
}