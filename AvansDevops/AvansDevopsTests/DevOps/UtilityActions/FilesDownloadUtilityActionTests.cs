using AvansDevops.DevOps.UtilityActions;

namespace AvansDevopsTests.DevOps.UtilityActions;

public class FilesDownloadUtilityActionTests
{
    [Fact]
    public void RunUtilityActionShouldReturnTrue()
    {
        // Arrange
        var action = new FilesDownloadUtilityAction("");

        // Act
        var result = action.RunUtilityAction();

        // Assert
        Assert.True(result);
    }
}