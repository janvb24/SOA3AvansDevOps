using AvansDevops.DevOps.AnalysisActions;
using AvansDevops.DevOps.BuildActions;
using AvansDevops.DevOps.DeployActions;
using AvansDevops.DevOps.PackageActions;
using AvansDevops.DevOps.SourceActions;
using AvansDevops.DevOps.TestActions;
using AvansDevops.DevOps.UtilityActions;

namespace AvansDevops.DevOps;

public interface IPipelineVisitor
{
    
    /// <summary>
    /// Run's the pipeline that is being visited
    /// </summary>
    /// <param name="pipeline">The pipeline to be visited</param>
    public void VisitPipeline(Pipeline pipeline);

    /// <summary>
    /// Run's the source action that is being visited
    /// </summary>
    /// <param name="action">Source action to be visited</param>
    /// <returns>True if action went successfully, False if not</returns>
    public bool VisitSourceAction(SourceAction action);
    
    /// <summary>
    /// Run's the package action that is being visited
    /// </summary>
    /// <param name="action">Package action to be visited</param>
    /// <returns>True if action went successfully, False if not</returns>
    public bool VisitPackageAction(PackageAction action);
    
    /// <summary>
    /// Run's the build action that is being visited
    /// </summary>
    /// <param name="action">Build action to be visited</param>
    /// <returns>True if action went successfully, False if not</returns>
    public bool VisitBuildAction(BuildAction action);
    
    /// <summary>
    /// Run's the test action that is being visited
    /// </summary>
    /// <param name="action">Test action to be visited</param>
    /// <returns>True if action went successfully, False if not</returns>
    public bool VisitTestAction(TestAction action);
    
    /// <summary>
    /// Run's the analysis action that is being visited
    /// </summary>
    /// <param name="action">Analysis action to be visited</param>
    /// <returns>True if action went successfully, False if not</returns>
    public bool VisitAnalysisAction(AnalysisAction action);
    
    /// <summary>
    /// Run's the utility action that is being visited
    /// </summary>
    /// <param name="action">Utility action to be visited</param>
    /// <returns>True if action went successfully, False if not</returns>
    public bool VisitUtilityAction(UtilityAction action);
    
    /// <summary>
    /// Run's the deployment action that is being visited
    /// </summary>
    /// <param name="action">Deployment action to be visited</param>
    /// <returns>True if action went successfully, False if not</returns>
    public bool VisitDeployAction(DeployAction action);

}