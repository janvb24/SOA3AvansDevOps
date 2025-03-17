using AvansDevops.Notifications;

namespace AvansDevops.DevOps;

public class Pipeline : Composite
{
    
    private readonly INotificationService _notificationService;
    
    public Pipeline(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }
    
    public override bool Accept(IPipelineVisitor visitor)
    {
        visitor.VisitPipeline(this);
        return base.Accept(visitor);
    }
    
}