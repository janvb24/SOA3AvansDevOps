namespace AvansDevops.DevOps;

public abstract class Component
{
    
    public abstract bool Accept(IPipelineVisitor visitor);
    
}