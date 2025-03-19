using AvansDevops.DevOps;
using AvansDevops.DevOps.AnalysisActions;
using AvansDevops.DevOps.BuildActions;
using AvansDevops.DevOps.DeployActions;
using AvansDevops.DevOps.PackageActions;
using AvansDevops.DevOps.SourceActions;
using AvansDevops.DevOps.TestActions;
using AvansDevops.DevOps.UtilityActions;
using AvansDevops.Notifications;

namespace AvansDevopsTests.DevOps;

public class ConcretePipelineBuilderTests
{
    [Fact]
    public void ShouldBuildPipeline()
    {
        // Arrange
        IPipelineBuilder pipelineBuilder = new ConcretePipelineBuilder();
        var expected = new Pipeline(new NotificationService());
        
        // Act
        var result = pipelineBuilder.Build();

        // Assert
        Assert.Equivalent(expected, result, true);
    }

    [Fact]
    public void ShouldReturnConcretePipelineBuilderWithPackageAction()
    {
        // Arrange
        IPipelineBuilder pipelineBuilder = new ConcretePipelineBuilder();
        var packageAction = Substitute.For<PackageAction>("https://www.google.com");
        var expected = new Pipeline(new NotificationService());
        expected.Add(packageAction);

        // Act
        var result = pipelineBuilder.AddPackageAction(packageAction).Build();

        // Assert
        Assert.Equivalent(expected, result, true);
    }
    
    [Fact]
    public void ShouldReturnConcretePipelineBuilderWithSourceAction()
    {
        // Arrange
        IPipelineBuilder pipelineBuilder = new ConcretePipelineBuilder();
        var sourceAction = Substitute.For<SourceAction>("https://www.google.com");
        var expected = new Pipeline(new NotificationService());
        expected.Add(sourceAction);

        // Act
        var result = pipelineBuilder.AddSourceAction(sourceAction).Build();

        // Assert
        Assert.Equivalent(expected, result, true);
    }
    
    [Fact]
    public void ShouldReturnConcretePipelineBuilderWithBuildAction()
    {
        // Arrange
        IPipelineBuilder pipelineBuilder = new ConcretePipelineBuilder();
        var buildAction = Substitute.For<BuildAction>();
        var expected = new Pipeline(new NotificationService());
        expected.Add(buildAction);

        // Act
        var result = pipelineBuilder.AddBuildAction(buildAction).Build();

        // Assert
        Assert.Equivalent(expected, result, true);
    }
    
    [Fact]
    public void ShouldReturnConcretePipelineBuilderWithTestAction()
    {
        // Arrange
        IPipelineBuilder pipelineBuilder = new ConcretePipelineBuilder();
        var testAction = Substitute.For<TestAction>();
        var expected = new Pipeline(new NotificationService());
        expected.Add(testAction);

        // Act
        var result = pipelineBuilder.AddTestAction(testAction).Build();

        // Assert
        Assert.Equivalent(expected, result, true);
    }
    
    [Fact]
    public void ShouldReturnConcretePipelineBuilderWithAnalysisAction()
    {
        // Arrange
        IPipelineBuilder pipelineBuilder = new ConcretePipelineBuilder();
        var analysisAction = Substitute.For<AnalysisAction>();
        var expected = new Pipeline(new NotificationService());
        expected.Add(analysisAction);

        // Act
        var result = pipelineBuilder.AddAnalysisAction(analysisAction).Build();

        // Assert
        Assert.Equivalent(expected, result, true);
    }
    
    [Fact]
    public void ShouldReturnConcretePipelineBuilderWithUtilityAction()
    {
        // Arrange
        IPipelineBuilder pipelineBuilder = new ConcretePipelineBuilder();
        var utilityAction = Substitute.For<UtilityAction>("");
        var expected = new Pipeline(new NotificationService());
        expected.Add(utilityAction);

        // Act
        var result = pipelineBuilder.AddUtilityAction(utilityAction).Build();

        // Assert
        Assert.Equivalent(expected, result, true);
    }
    
    [Fact]
    public void ShouldReturnConcretePipelineBuilderWithDeployAction()
    {
        // Arrange
        IPipelineBuilder pipelineBuilder = new ConcretePipelineBuilder();
        var deployAction = Substitute.For<DeployAction>("https://www.google.com");
        var expected = new Pipeline(new NotificationService());
        expected.Add(deployAction);

        // Act
        var result = pipelineBuilder.AddDeployAction(deployAction).Build();

        // Assert
        Assert.Equivalent(expected, result, true);
    }
    
}