namespace AvansDevops.DevOps.BuildActions;

public class AntBuildAction : BuildAction
{
    
    public override bool Build()
    {
        Console.WriteLine("Building Ant project");
        return true;
    }
    
}