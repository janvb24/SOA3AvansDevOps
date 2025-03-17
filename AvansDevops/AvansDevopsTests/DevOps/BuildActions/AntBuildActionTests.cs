using AvansDevops.DevOps.BuildActions;

namespace AvansDevopsTests.DevOps.BuildActions;

public class AntBuildActionTests
{
    [Fact]
    public void BuildShouldReturnTrue()
    {
        // Arrange
        var action = new AntBuildAction();

        // Act
        var result = action.Build();

        // Assert
        Assert.True(result);
    }
}