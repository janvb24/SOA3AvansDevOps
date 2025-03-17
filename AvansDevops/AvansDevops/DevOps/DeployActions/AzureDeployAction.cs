namespace AvansDevops.DevOps.DeployActions;

public class AzureDeployAction(string url) : DeployAction(url)
{
    
    public override bool Deploy()
    {
        Console.WriteLine($"Deploying to Azure on {url}");
        return true;
    }
    
}