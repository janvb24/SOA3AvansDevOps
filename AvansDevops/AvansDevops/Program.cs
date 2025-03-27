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
using AvansDevops.ProjectManagementSystem.sprint;

//Notification service
INotificationService notificationService = new NotificationService();

//Users
List<User> developers = [new User("dev", "dev@email.nl", "0638475686")];
User tester = new User("test", "test@email.nl", "0638475686");
User leadDev = new User("leadDev", "leadDev@email.nl", "0638475686");
User productOwner = new User("productOwner", "productOwner@email.nl", "0638475686");
User scrumMaster = new User("scrum", "scrum@email.nl", "0638475686");

//Version Control
IGitVersionControl versionControl = new GitVersionControl(
    new BranchGitVersionControlAction(), 
    new CommitGitVersionControlAction(), 
    new FetchGitVersionControlAction(), 
    new PushGitVersionControlAction()
);

//Project with backlog
Project project = new(versionControl, developers, tester, leadDev, productOwner);
project.projectBacklog.AddBacklogItem(new EditableBacklogItem("Initialize Git", 1, null, tester, scrumMaster));
var backlogItem = new EditableBacklogItem("Add domain model", 8, developers[0], tester, scrumMaster);
backlogItem.subTasks!.Add(new EditableBacklogItem("Add User domain model class", 5, developers[0], tester, scrumMaster, null, backlogItem));
backlogItem.subTasks.Add(new EditableBacklogItem("Add role domain model ENUM", 1, developers[0], tester, scrumMaster, null, backlogItem));
backlogItem.subTasks.Add(new EditableBacklogItem("Add Task domain model class", 3, developers[0], tester, scrumMaster, null, backlogItem));
project.projectBacklog.AddBacklogItem(backlogItem);

//Forum
ForumTread tread = new ForumTread(notificationService, developers[0]);
tread.items.Add(new ForumTreadItem("Item 1", developers[0]));
tread.items[0].nextTreadItem = new ForumTreadItem("new item after item 1", developers[0]);
tread.items[0].nextTreadItem = new ForumTreadItem("extra new content", developers[0]);
project.forum.newTread(tread);
Console.WriteLine(tread.items[0]);

//Backlog state
backlogItem.currentState.Start(); //TODO --> DOINT
backlogItem.currentState.Complete(); //DOING --> READY FOR TESTING
backlogItem.currentState.Start(); //READY FOR TESTING --> TESTING
backlogItem.currentState.Deny(); //TESTING --> TODO
backlogItem.currentState.Start(); //TODO --> DOING
backlogItem.currentState.Complete(); //DOING --> READY FOR TESTING
backlogItem.currentState.Start(); //READY FOR TESTING --> TESTING
backlogItem.currentState.Complete(); //TESTING --> TESTED 
backlogItem.currentState.Deny(); //TESTED --> ReadyForTesting 
backlogItem.currentState.Start(); //READY FOR TESTING --> TESTING
backlogItem.currentState.Complete(); //TESTING --> TESTED 
backlogItem.currentState.Approve(); //TESTED --> DONE

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

// Sprint
project.NewSprint(scrumMaster, pipeline, "My sprint", SprintType.RELEASE_SPRINT);
project.currentSprint.AddToBacklog(backlogItem);
