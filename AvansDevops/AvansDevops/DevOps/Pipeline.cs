namespace AvansDevops.DevOps;

public class Pipeline : Composite
{
    
    /**
     * TODO: Add notification service
     */
    public Pipeline()
    {
        
    }
    
    public override bool Accept(IPipelineVisitor visitor)
    {
        visitor.VisitPipeline(this);
        return base.Accept(visitor);
    }
}