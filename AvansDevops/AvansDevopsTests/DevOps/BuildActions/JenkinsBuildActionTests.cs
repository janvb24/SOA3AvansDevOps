using AvansDevops.DevOps.BuildActions;

namespace AvansDevopsTests.DevOps.BuildActions;

public class JenkinsBuildActionTests
{
    [Fact]
    public void BuildShouldReturnTrue()
    {
        // Arrange
        var action = new JenkinsBuildAction();

        // Act
        var result = action.Build();

        // Assert
        Assert.True(result);
    }
}