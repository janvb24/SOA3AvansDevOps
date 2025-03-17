using AvansDevops.ProjectManagementSystem;
using AvansDevops.ProjectManagementSystem.backlog;
using AvansDevops.SoftwareConfigurationManagement;
using AvansDevops.SoftwareConfigurationManagement.GitActions.BranchAction;
using AvansDevops.SoftwareConfigurationManagement.GitActions.CommitAction;
using AvansDevops.SoftwareConfigurationManagement.GitActions.FetchAction;
using AvansDevops.SoftwareConfigurationManagement.GitActions.PushAction;
using AvansDevops.DevOps;

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
backlogItem.subTasks.Add(new EditableBacklogItem("Add User domain model class", 5, developer, null, backlogItem));
backlogItem.subTasks.Add(new EditableBacklogItem("Add role domain model ENUM", 1, developer, null, backlogItem));
backlogItem.subTasks.Add(new EditableBacklogItem("Add Task domain model class", 3, developer, null, backlogItem));
project.projectBacklog.AddBacklogItem(backlogItem);

IPipelineBuilder pipelineBuilder = new ConcretePipelineBuilder();
Pipeline pipeline = pipelineBuilder.Build();
IPipelineVisitor visitor = new RunPipelineVisitor();
pipeline.Accept(visitor);

