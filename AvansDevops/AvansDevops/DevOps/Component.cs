namespace AvansDevops.DevOps;

public abstract class Component
{
    
    /// <summary>
    /// The function that will be called when the pipeline is executed.
    /// </summary>
    /// <param name="visitor">The visitor to be used when running the pipeline</param>
    /// <returns>True if the pipeline succeeded. False if the pipeline failed.</returns>
    public abstract bool Accept(IPipelineVisitor visitor);
    
}