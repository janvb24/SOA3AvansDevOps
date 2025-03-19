﻿using AvansDevops.Notifications;

namespace AvansDevops.DevOps;

public class Pipeline : Composite
{

    public bool succeeded { get; private set; }
    private readonly INotificationService _notificationService;
    
    public Pipeline(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }
    
    public override bool Accept(IPipelineVisitor visitor)
    {
        succeeded = base.Accept(visitor);
        visitor.VisitPipeline(this);
        return succeeded;
    }
    
}