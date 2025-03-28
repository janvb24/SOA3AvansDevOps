using AvansDevops.DevOps.AnalysisActions;
using AvansDevops.DevOps.BuildActions;
using AvansDevops.DevOps.DeployActions;
using AvansDevops.DevOps.PackageActions;
using AvansDevops.DevOps.SourceActions;
using AvansDevops.DevOps.TestActions;
using AvansDevops.DevOps.UtilityActions;

namespace AvansDevops.DevOps;

public class RunPipelineVisitor : IPipelineVisitor
{
    
    public void VisitPipeline(ConcretePipeline pipeline)
    {
        Console.WriteLine(!pipeline.succeeded ? 
            "Pipeline failed!" : 
            "Pipeline completed without errors");
    }
    
    public bool VisitSourceAction(SourceAction action)
    {
        var succeeded = action.GetSource();
        if (succeeded)
        {
            Console.WriteLine("Fetched source successfully");
            return true;
        }
        Console.WriteLine($"Failed while fetching source from {action.url}");
        return false;
    }

    public bool VisitPackageAction(PackageAction action)
    {
        var succeeded = action.GetPackage();
        if (succeeded)
        {
            Console.WriteLine("Fetched package successfully");
            return true;
        }
        Console.WriteLine($"Failed while fetching package from {action.url}");
        return false;
    }

    public bool VisitBuildAction(BuildAction action)
    {
        var succeeded = action.Build();
        if (succeeded)
        {
            Console.WriteLine("Built project successfully");
            return true;
        }
        Console.WriteLine("Failed while building");
        return false;
    }

    public bool VisitTestAction(TestAction action)
    {
        var succeeded = action.RunTestAction();
        if (succeeded)
        {
            Console.WriteLine("Ran test action successfully");
            return true;
        }
        Console.WriteLine("Failed while running tests");
        return false;
    }

    public bool VisitAnalysisAction(AnalysisAction action)
    {
        var succeeded = action.RunAnalysis();
        if (succeeded)
        {
            Console.WriteLine("Ran analysis successfully");
            return true;
        }
        Console.WriteLine("Failed while running analysis");
        return false;
    }

    public bool VisitUtilityAction(UtilityAction action)
    {
        var succeeded = action.RunUtilityAction();
        if (succeeded)
        {
            Console.WriteLine("Ran utility successfully");
            return true;
        }
        Console.WriteLine($"Failed while running utility: {action.context}");
        return false;
    }

    public bool VisitDeployAction(DeployAction action)
    {
        var succeeded = action.Deploy();
        if (succeeded)
        {
            Console.WriteLine("Deployed application successfully");
            return true;
        }
        Console.WriteLine($"Failed while deploying to {action.url}");
        return false;
    }
    
}