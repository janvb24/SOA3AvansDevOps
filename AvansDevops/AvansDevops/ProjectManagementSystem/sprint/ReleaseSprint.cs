using AvansDevops.DevOps;
using AvansDevops.DevOps.DeployActions;

namespace AvansDevops.ProjectManagementSystem.sprint;

public class ReleaseSprint : Sprint
{
    public ReleaseSprint(Project project, User scrumMaster, Pipeline pipeline, string name) : 
        base(project, scrumMaster, pipeline, name)
    {
        if (pipeline.GetActions().Last() is not DeployAction)
            throw new ArgumentException("ReleaseSprint should have a DeployAction as last action in pipeline");
    }
}