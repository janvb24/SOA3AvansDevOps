namespace AvansDevops.DevOps.TestActions;

public abstract class TestAction : Component
{
    
    public override bool Accept(IPipelineVisitor visitor)
    {
        return visitor.VisitTestAction(this);
    }
    
    /// <summary>
    /// Method to run test action
    /// </summary>
    /// <returns>True if test action went successfully, False if not</returns>
    public abstract bool RunTestAction();
    
}