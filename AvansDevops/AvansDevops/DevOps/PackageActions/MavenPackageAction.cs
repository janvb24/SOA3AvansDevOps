namespace AvansDevops.DevOps.PackageActions;

public class MavenPackageAction(string url) : PackageAction(url)
{
    
    public override bool GetPackage()
    {
        Console.WriteLine($"Fetching Maven package from {url}");
        return true;
    }
    
}