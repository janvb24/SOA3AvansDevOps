namespace AvansDevops.DevOps.PackageActions;

public class NugetPackageAction(string url) : PackageAction(url)
{
    
    public override bool GetPackage()
    {
        Console.WriteLine($"Fetching Nuget package from {url}");
        return true;
    }
    
}