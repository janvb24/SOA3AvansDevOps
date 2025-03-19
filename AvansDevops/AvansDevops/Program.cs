using AvansDevops.ProjectManagementSystem;
using AvansDevops.ProjectManagementSystem.backlog;
using AvansDevops.SoftwareConfigurationManagement;
using AvansDevops.SoftwareConfigurationManagement.GitActions.BranchAction;
using AvansDevops.SoftwareConfigurationManagement.GitActions.CommitAction;
using AvansDevops.SoftwareConfigurationManagement.GitActions.FetchAction;
using AvansDevops.SoftwareConfigurationManagement.GitActions.PushAction;
using AvansDevops.DevOps;
using AvansDevops.DevOps.AnalysisActions;
using AvansDevops.DevOps.BuildActions;
using AvansDevops.DevOps.DeployActions;
using AvansDevops.DevOps.PackageActions;
using AvansDevops.DevOps.SourceActions;
using AvansDevops.DevOps.TestActions;
using AvansDevops.DevOps.UtilityActions;
using AvansDevops.ProjectManagementSystem.forum;
using AvansDevops.Notifications;

//Notification service
INotificationService notificationService = new NotificationService();

//Users
User developer = new User("Jan", "jan@email.nl", "0638475686");

//Version Control
IGitVersionControl versionControl = new GitVersionControl(
    new BranchGitVersionControlAction(), 
    new CommitGitVersionControlAction(), 
    new FetchGitVersionControlAction(), 
    new PushGitVersionControlAction()
);

//Project with backlog
Project project = new(versionControl);
project.projectBacklog.AddBacklogItem(new EditableBacklogItem("Initialize Git", 1));
var backlogItem = new EditableBacklogItem("Add domain model", 8, developer);
backlogItem.subTasks!.Add(new EditableBacklogItem("Add User domain model class", 5, developer, null, backlogItem));
backlogItem.subTasks.Add(new EditableBacklogItem("Add role domain model ENUM", 1, developer, null, backlogItem));
backlogItem.subTasks.Add(new EditableBacklogItem("Add Task domain model class", 3, developer, null, backlogItem));
project.projectBacklog.AddBacklogItem(backlogItem);

//Forum
ForumTread tread = new ForumTread(notificationService, developer);
tread.items.Add(new ForumTreadItem("Item 1", developer));
tread.items[0].nextTreadItem = new ForumTreadItem("new item after item 1", developer);
tread.items[0].nextTreadItem = new ForumTreadItem("extra new content", developer);
project.forum.newTread(tread);
Console.WriteLine(tread.items[0]);

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

