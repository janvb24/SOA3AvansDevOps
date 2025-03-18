using AvansDevops.ProjectManagementSystem;
using AvansDevops.ProjectManagementSystem.backlog;
using AvansDevops.SoftwareConfigurationManagement;
using AvansDevops.SoftwareConfigurationManagement.GitActions.BranchAction;
using AvansDevops.SoftwareConfigurationManagement.GitActions.CommitAction;
using AvansDevops.SoftwareConfigurationManagement.GitActions.FetchAction;
using AvansDevops.SoftwareConfigurationManagement.GitActions.PushAction;
using AvansDevops.DevOps;

//Users
User developer = new User("dev", "dev@email.nl", "0638475686");
User tester = new User("test", "test@email.nl", "0638475686");
User scrumMaster = new User("scrum", "scrum@email.nl", "0638475686");


//Version Control
IGitVersionControl versionControl = new GitVersionControl(
    new BranchGitVersionControlAction(), 
    new CommitGitVersionControlAction(), 
    new FetchGitVersionControlAction(), 
    new PushGitVersionControlAction()
);

//Project with backlog
Project project = new(versionControl, developer);
project.projectBacklog.AddBacklogItem(new EditableBacklogItem("Initialize Git", 1, developer, tester, scrumMaster));
var backlogItem = new EditableBacklogItem("Add domain model", 8, developer, tester, scrumMaster);
backlogItem.subTasks!.Add(new EditableBacklogItem("Add User domain model class", 5, developer, tester, scrumMaster, null, backlogItem));
backlogItem.subTasks.Add(new EditableBacklogItem("Add role domain model ENUM", 1, developer, tester, scrumMaster, null, backlogItem));
backlogItem.subTasks.Add(new EditableBacklogItem("Add Task domain model class", 3, developer, tester, scrumMaster, null, backlogItem));
project.projectBacklog.AddBacklogItem(backlogItem);

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

//Pipeline
IPipelineBuilder pipelineBuilder = new ConcretePipelineBuilder();
Pipeline pipeline = pipelineBuilder.Build();
IPipelineVisitor visitor = new RunPipelineVisitor();
pipeline.Accept(visitor);

