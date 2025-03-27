using AvansDevops.Notifications;

namespace AvansDevops.DevOps;

public class ConcretePipeline : Pipeline
{

    public bool succeeded { get; private set; }
    private readonly INotificationService _notificationService;
    
    public ConcretePipeline(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }
    
    public override bool Accept(IPipelineVisitor visitor)
    {
        succeeded = base.Accept(visitor);
        visitor.VisitPipeline(this);
        return succeeded;
    }

    public override List<Component> GetActions()
    {
        return parts;
    }
}