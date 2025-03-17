using AvansDevops.DevOps.UtilityActions;

namespace AvansDevopsTests.DevOps.UtilityActions;

public class FilesCopyUtilityActionTests
{
    [Fact]
    public void RunUtilityActionShouldReturnTrue()
    {
        // Arrange
        var action = new FilesCopyUtilityAction("");

        // Act
        var result = action.RunUtilityAction();

        // Assert
        Assert.True(result);
    }
}