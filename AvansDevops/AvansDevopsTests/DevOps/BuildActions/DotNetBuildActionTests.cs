using AvansDevops.DevOps.BuildActions;

namespace AvansDevopsTests.DevOps.BuildActions;

public class DotNetBuildActionTests
{
    [Fact]
    public void BuildShouldReturnTrue()
    {
        // Arrange
        var action = new DotNetBuildAction();

        // Act
        var result = action.Build();

        // Assert
        Assert.True(result);
    }
}