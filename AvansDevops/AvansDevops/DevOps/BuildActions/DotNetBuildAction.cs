namespace AvansDevops.DevOps.BuildActions;

public class DotNetBuildAction : BuildAction
{
    
    public override bool Build()
    {
        Console.WriteLine("Building .NET project");
        return true;
    }
    
}