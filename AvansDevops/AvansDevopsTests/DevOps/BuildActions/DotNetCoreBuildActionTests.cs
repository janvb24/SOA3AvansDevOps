using AvansDevops.DevOps.BuildActions;

namespace AvansDevopsTests.DevOps.BuildActions;

public class DotNetCoreBuildActionTests
{
    [Fact]
    public void BuildShouldReturnTrue()
    {
        // Arrange
        var action = new DotNetCoreBuildAction();

        // Act
        var result = action.Build();

        // Assert
        Assert.True(result);
    }
}