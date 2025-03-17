using AvansDevops.DevOps;
using AvansDevops.DevOps.AnalysisActions;
using AvansDevops.DevOps.BuildActions;
using AvansDevops.DevOps.PackageActions;
using AvansDevops.DevOps.SourceActions;
using AvansDevops.DevOps.TestActions;
using AvansDevops.DevOps.UtilityActions;

namespace AvansDevopsTests.DevOps;

public class RunPipelineVisitorTests
{
    [Fact]
    public void VisitSourceActionShouldFailWithFailingSourceAction()
    {
        // Arrange
        IPipelineVisitor visitor = new RunPipelineVisitor();
        var action = Substitute.For<SourceAction>("https://www.google.com");
        action.GetSource().Returns(false);

        // Act
        bool result = visitor.VisitSourceAction(action);

        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void VisitSourceActionShouldSucceedWithFailingSourceAction()
    {
        // Arrange
        IPipelineVisitor visitor = new RunPipelineVisitor();
        var action = Substitute.For<SourceAction>("https://www.google.com");
        action.GetSource().Returns(true);

        // Act
        bool result = visitor.VisitSourceAction(action);

        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void VisitSourceActionShouldFailWithFailingPackageAction()
    {
        // Arrange
        IPipelineVisitor visitor = new RunPipelineVisitor();
        var action = Substitute.For<PackageAction>("https://www.google.com");
        action.GetPackage().Returns(false);

        // Act
        bool result = visitor.VisitPackageAction(action);

        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void VisitSourceActionShouldSucceedWithFailingPackageAction()
    {
        // Arrange
        IPipelineVisitor visitor = new RunPipelineVisitor();
        var action = Substitute.For<PackageAction>("https://www.google.com");
        action.GetPackage().Returns(true);

        // Act
        bool result = visitor.VisitPackageAction(action);

        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void VisitSourceActionShouldFailWithFailingBuildAction()
    {
        // Arrange
        IPipelineVisitor visitor = new RunPipelineVisitor();
        var action = Substitute.For<BuildAction>();
        action.Build().Returns(false);

        // Act
        bool result = visitor.VisitBuildAction(action);

        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void VisitSourceActionShouldSucceedWithFailingBuildAction()
    {
        // Arrange
        IPipelineVisitor visitor = new RunPipelineVisitor();
        var action = Substitute.For<BuildAction>();
        action.Build().Returns(true);

        // Act
        bool result = visitor.VisitBuildAction(action);

        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void VisitSourceActionShouldFailWithFailingTestAction()
    {
        // Arrange
        IPipelineVisitor visitor = new RunPipelineVisitor();
        var action = Substitute.For<TestAction>();
        action.RunTestAction().Returns(false);

        // Act
        bool result = visitor.VisitTestAction(action);

        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void VisitSourceActionShouldSucceedWithFailingTestAction()
    {
        // Arrange
        IPipelineVisitor visitor = new RunPipelineVisitor();
        var action = Substitute.For<TestAction>();
        action.RunTestAction().Returns(true);

        // Act
        bool result = visitor.VisitTestAction(action);

        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void VisitSourceActionShouldFailWithFailingAnalysisAction()
    {
        // Arrange
        IPipelineVisitor visitor = new RunPipelineVisitor();
        var action = Substitute.For<AnalysisAction>();
        action.RunAnalysis().Returns(false);

        // Act
        bool result = visitor.VisitAnalysisAction(action);

        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void VisitSourceActionShouldSucceedWithFailingAnalysisAction()
    {
        // Arrange
        IPipelineVisitor visitor = new RunPipelineVisitor();
        var action = Substitute.For<AnalysisAction>();
        action.RunAnalysis().Returns(true);

        // Act
        bool result = visitor.VisitAnalysisAction(action);

        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void VisitSourceActionShouldFailWithFailingUtilityAction()
    {
        // Arrange
        IPipelineVisitor visitor = new RunPipelineVisitor();
        var action = Substitute.For<UtilityAction>("");
        action.RunUtilityAction().Returns(false);

        // Act
        bool result = visitor.VisitUtilityAction(action);

        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void VisitSourceActionShouldSucceedWithFailingUtilityAction()
    {
        // Arrange
        IPipelineVisitor visitor = new RunPipelineVisitor();
        var action = Substitute.For<UtilityAction>("");
        action.RunUtilityAction().Returns(true);

        // Act
        bool result = visitor.VisitUtilityAction(action);

        // Assert
        Assert.True(result);
    }
}