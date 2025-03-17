namespace AvansDevops.DevOps.PackageActions;

public abstract class PackageAction : Component
{

    public string url { get; }
    
    public PackageAction(string url)
    {
        this.url = url;
    }
    
    /// <summary>
    /// Method to fetch a package
    /// </summary>
    /// <returns>True if fetching package went successfully, False if not</returns>
    public abstract bool GetPackage();
    
    public override bool Accept(IPipelineVisitor visitor)
    {
        return visitor.VisitPackageAction(this);
    }
    
}