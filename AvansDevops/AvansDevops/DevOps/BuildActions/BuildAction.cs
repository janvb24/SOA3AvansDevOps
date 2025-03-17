namespace AvansDevops.DevOps.BuildActions;

public abstract class BuildAction : Component
{

    /// <summary>
    /// Method to build application
    /// </summary>
    /// <returns>True if build went successfully, False if not</returns>
    public abstract bool Build();
    
    public override bool Accept(IPipelineVisitor visitor)
    {
        return visitor.VisitBuildAction(this);
    }
    
}