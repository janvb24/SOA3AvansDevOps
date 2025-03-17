// See https://aka.ms/new-console-template for more information

using AvansDevops.DevOps;
using AvansDevops.DevOps.AnalysisActions;
using AvansDevops.DevOps.BuildActions;
using AvansDevops.DevOps.DeployActions;
using AvansDevops.DevOps.PackageActions;
using AvansDevops.DevOps.SourceActions;
using AvansDevops.DevOps.TestActions;
using AvansDevops.DevOps.UtilityActions;

// Build and run a CICD pipeline
IPipelineBuilder pipelineBuilder = new ConcretePipelineBuilder();
Pipeline pipeline = pipelineBuilder
    .AddUtilityAction(new CmdUtilityAction("Echo Hello world!"))
    .AddSourceAction(new GitSourceAction("https://github.com/janvb24/SOA3AvansDevOps.git"))
    .AddPackageAction(new NugetPackageAction("https://www.nuget.org/packages/xunit"))
    .AddBuildAction(new DotNetCoreBuildAction())
    .AddTestAction(new RunTestsAction())
    .AddTestAction(new PublishCodeCoverageResultAction())
    .AddAnalysisAction(new SonarqubeAnalysisAction())
    .AddDeployAction(new AzureDeployAction("https://www.azure.com"))
    .Build();
IPipelineVisitor visitor = new RunPipelineVisitor();
pipeline.Accept(visitor);
