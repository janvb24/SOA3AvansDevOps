namespace AvansDevops.DevOps.DeployActions;

public class CustomDeployAction(string url) : DeployAction(url)
{
    
    public override bool Deploy()
    {
        Console.WriteLine($"Deploying to {url}");
        return true;
    }
    
}