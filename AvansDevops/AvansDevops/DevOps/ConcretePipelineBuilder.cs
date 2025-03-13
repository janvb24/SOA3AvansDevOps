namespace AvansDevops.DevOps;

public class ConcretePipelineBuilder : IPipelineBuilder
{
    
    private readonly Pipeline _pipeline = new();
    
    public Pipeline Build()
    {
        return _pipeline;
    }
    
}