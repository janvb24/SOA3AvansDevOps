namespace AvansDevops.DevOps.UtilityActions;

public abstract class UtilityAction : Component
{

    public string context { get; }
    
    public UtilityAction(string context)
    {
        this.context = context;
    }
    
    public override bool Accept(IPipelineVisitor visitor)
    {
        return visitor.VisitUtilityAction(this);
    }

    /// <summary>
    /// Method to run utility action
    /// </summary>
    /// <returns>True if utility action went successfully, False if not</returns>
    public abstract bool RunUtilityAction();

}