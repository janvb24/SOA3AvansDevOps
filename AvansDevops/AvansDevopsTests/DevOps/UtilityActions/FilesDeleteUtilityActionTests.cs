using AvansDevops.DevOps.UtilityActions;

namespace AvansDevopsTests.DevOps.UtilityActions;

public class FilesDeleteUtilityActionTests
{
    [Fact]
    public void RunUtilityActionShouldReturnTrue()
    {
        // Arrange
        var action = new FilesDeleteUtilityAction("");

        // Act
        var result = action.RunUtilityAction();

        // Assert
        Assert.True(result);
    }
}