namespace AvansDevops.DevOps.SourceActions;

public abstract class SourceAction : Component
{

    public string url { get; }

    public SourceAction(string url)
    {
        this.url = url;
    }
    
    /// <summary>
    /// Method to fetch a source
    /// </summary>
    /// <returns>True if fetching source went successfully, False if not</returns>
    public abstract bool GetSource();
    
    public override bool Accept(IPipelineVisitor visitor)
    {
        return visitor.VisitSourceAction(this);
    }
    
}