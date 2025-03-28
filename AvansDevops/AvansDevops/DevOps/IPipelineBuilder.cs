using AvansDevops.DevOps.AnalysisActions;
using AvansDevops.DevOps.BuildActions;
using AvansDevops.DevOps.DeployActions;
using AvansDevops.DevOps.PackageActions;
using AvansDevops.DevOps.SourceActions;
using AvansDevops.DevOps.TestActions;
using AvansDevops.DevOps.UtilityActions;

namespace AvansDevops.DevOps;

public interface IPipelineBuilder
{

    /// <summary>
    /// Builds the pipeline and returns a concrete pipeline.
    /// </summary>
    /// <returns>The concrete pipeline build with the builder.</returns>
    public ConcretePipeline Build();

    public IPipelineBuilder AddPackageAction(PackageAction action);
    
    /// <summary>
    /// Adds a source action to the pipeline
    /// </summary>
    /// <param name="action">Source action to be added</param>
    public IPipelineBuilder AddSourceAction(SourceAction action);
    
    /// <summary>
    /// Adds a build action to the pipeline
    /// </summary>
    /// <param name="action">Build action to be added</param>
    public IPipelineBuilder AddBuildAction(BuildAction action);
    
    /// <summary>
    /// Adds a test action to the pipeline
    /// </summary>
    /// <param name="action">Test action to be added</param>
    public IPipelineBuilder AddTestAction(TestAction action);
    
    /// <summary>
    /// Adds an analysis action to the pipeline
    /// </summary>
    /// <param name="action">Analysis action to be added</param>
    public IPipelineBuilder AddAnalysisAction(AnalysisAction action);
    
    /// <summary>
    /// Adds a utility action to the pipeline
    /// </summary>
    /// <param name="action">Utility action to be added</param>
    public IPipelineBuilder AddUtilityAction(UtilityAction action);
    
    /// <summary>
    /// Adds a deployment action to the pipeline
    /// </summary>
    /// <param name="action">Deployment action to be added</param>
    public IPipelineBuilder AddDeployAction(DeployAction action);

}