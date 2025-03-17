using AvansDevops.DevOps.TestActions;

namespace AvansDevopsTests.DevOps.TestActions;

public class PublishTestResultActionTests
{
    [Fact]
    public void RunTestActionShouldReturnTrue()
    {
        // Arrange
        var action = new PublishTestResultAction();

        // Act
        var result = action.RunTestAction();

        // Assert
        Assert.True(result);
    }
}