using AvansDevops.DevOps.BuildActions;

namespace AvansDevopsTests.DevOps.BuildActions;

public class MavenBuildActionTests
{
    [Fact]
    public void BuildShouldReturnTrue()
    {
        // Arrange
        var action = new MavenBuildAction();

        // Act
        var result = action.Build();

        // Assert
        Assert.True(result);
    }
}