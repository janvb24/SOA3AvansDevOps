using AvansDevops.DevOps.TestActions;

namespace AvansDevopsTests.DevOps.TestActions;

public class RunTestsActionTests
{
    [Fact]
    public void RunTestActionShouldReturnTrue()
    {
        // Arrange
        var action = new RunTestsAction();

        // Act
        var result = action.RunTestAction();

        // Assert
        Assert.True(result);
    }
}