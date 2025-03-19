namespace AvansDevops.DevOps.DeployActions;

public abstract class DeployAction : Component
{

    public string url { get; }
    
    public DeployAction(string url)
    {
        this.url = url;
    }
    
    public override bool Accept(IPipelineVisitor visitor)
    {
        return visitor.VisitDeployAction(this);
    }

    /// <summary>
    /// Method to start deployment
    /// </summary>
    /// <returns>True if deployment went successfully, False if not</returns>
    public abstract bool Deploy();

}