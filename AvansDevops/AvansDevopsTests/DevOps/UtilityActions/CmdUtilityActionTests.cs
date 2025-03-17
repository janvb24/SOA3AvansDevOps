using AvansDevops.DevOps.UtilityActions;

namespace AvansDevopsTests.DevOps.UtilityActions;

public class CmdUtilityActionTests
{
    [Fact]
    public void RunUtilityActionShouldReturnTrue()
    {
        // Arrange
        var action = new CmdUtilityAction("");

        // Act
        var result = action.RunUtilityAction();

        // Assert
        Assert.True(result);
    }
}