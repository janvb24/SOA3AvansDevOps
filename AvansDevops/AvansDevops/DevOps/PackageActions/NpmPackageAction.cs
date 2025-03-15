namespace AvansDevops.DevOps.PackageActions;

public class NpmPackageAction(string url) : PackageAction(url)
{
    public override bool GetPackage()
    {
        Console.WriteLine($"Fetching NPM package from {url}");
        return true;
    }
    
}