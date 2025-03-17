using AvansDevops.Notifications;

namespace AvansDevops.DevOps;

public class ConcretePipelineBuilder : IPipelineBuilder
{
    
    private readonly Pipeline _pipeline = new(new NotificationService());
    
    public Pipeline Build()
    {
        return _pipeline;
    }
    
}