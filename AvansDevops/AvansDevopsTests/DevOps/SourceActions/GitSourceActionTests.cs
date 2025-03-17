using AvansDevops.DevOps.SourceActions;

namespace AvansDevopsTests.DevOps.SourceActions;

public class GitSourceActionTests
{
    [Fact]
    public void GetSourceShouldReturnTrue()
    {
        // Arrange
        var action = new GitSourceAction("https://www.google.com");

        // Act
        var result = action.GetSource();

        // Assert
        Assert.True(result);
    }
}