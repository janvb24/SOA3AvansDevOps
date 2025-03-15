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
        bool succeeded = base.Accept(visitor);

        if (!succeeded)
        {
            Console.WriteLine("Pipeline failed");
            return false;
        }

        return true;
    }
    
}