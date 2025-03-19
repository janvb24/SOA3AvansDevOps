using AvansDevops.DevOps.UtilityActions;

namespace AvansDevopsTests.DevOps.UtilityActions;

public class BatchUtilityActionTests
{
    [Fact]
    public void RunUtilityActionShouldReturnTrue()
    {
        // Arrange
        var action = new BatchUtilityAction("");

        // Act
        var result = action.RunUtilityAction();

        // Assert
        Assert.True(result);
    }
}