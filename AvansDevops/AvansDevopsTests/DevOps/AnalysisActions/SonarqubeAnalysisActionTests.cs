using AvansDevops.DevOps.AnalysisActions;

namespace AvansDevopsTests.DevOps.AnalysisActions;

public class SonarqubeAnalysisActionTests
{
    [Fact]
    public void RunAnalysisShouldReturnTrue()
    {
        // Arrange
        var action = new SonarqubeAnalysisAction();

        // Act
        var result = action.RunAnalysis();

        // Assert
        Assert.True(result);
    }
}