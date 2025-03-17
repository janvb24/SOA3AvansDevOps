namespace AvansDevops.DevOps.BuildActions;

public class MavenBuildAction : BuildAction
{
    
    public override bool Build()
    {
        Console.WriteLine("Building Maven project");
        return true;
    }
    
}