using AvansDevops.DevOps.AnalysisActions;
using AvansDevops.DevOps.BuildActions;
using AvansDevops.DevOps.DeployActions;
using AvansDevops.DevOps.PackageActions;
using AvansDevops.DevOps.SourceActions;
using AvansDevops.DevOps.TestActions;
using AvansDevops.DevOps.UtilityActions;
using AvansDevops.Notifications;

namespace AvansDevops.DevOps;

public class ConcretePipelineBuilder : IPipelineBuilder
{
    
    private readonly Pipeline _pipeline = new(new NotificationService());
    
    public Pipeline Build()
    {
        return _pipeline;
    }

    public IPipelineBuilder AddPackageAction(PackageAction action)
    {
        _pipeline.Add(action);
        return this;
    }

    public IPipelineBuilder AddSourceAction(SourceAction action)
    {
        _pipeline.Add(action);
        return this;
    }

    public IPipelineBuilder AddBuildAction(BuildAction action)
    {
        _pipeline.Add(action);
        return this;
    }

    public IPipelineBuilder AddTestAction(TestAction action)
    {
        _pipeline.Add(action);
        return this;
    }

    public IPipelineBuilder AddAnalysisAction(AnalysisAction action)
    {
        _pipeline.Add(action);
        return this;
    }

    public IPipelineBuilder AddUtilityAction(UtilityAction action)
    {
        _pipeline.Add(action);
        return this;
    }

    public IPipelineBuilder AddDeployAction(DeployAction action)
    {
        _pipeline.Add(action);
        return this;
    }
}