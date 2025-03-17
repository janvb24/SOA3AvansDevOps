namespace AvansDevops.DevOps.BuildActions;

public class DotNetCoreBuildAction : BuildAction
{
    
    public override bool Build()
    {
        Console.WriteLine("Building .NET Core project");
        return true;
    }
    
}