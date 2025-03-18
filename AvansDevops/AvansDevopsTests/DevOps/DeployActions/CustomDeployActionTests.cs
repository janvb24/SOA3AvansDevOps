using AvansDevops.DevOps.DeployActions;

namespace AvansDevopsTests.DevOps.DeployActions;

public class CustomDeployActionTests
{
    [Fact]
    public void DeployShouldReturnTrue()
    {
        // Arrange
        var action = new CustomDeployAction("https://www.google.com");

        // Act
        var result = action.Deploy();

        // Assert
        Assert.True(result);
    }
}