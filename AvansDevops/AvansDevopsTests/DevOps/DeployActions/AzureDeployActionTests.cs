using AvansDevops.DevOps.DeployActions;

namespace AvansDevopsTests.DevOps.DeployActions;

public class AzureDeployActionTests
{
    [Fact]
    public void DeployShouldReturnTrue()
    {
        // Arrange
        var action = new AzureDeployAction("https://www.google.com");

        // Act
        var result = action.Deploy();

        // Assert
        Assert.True(result);
    }
}