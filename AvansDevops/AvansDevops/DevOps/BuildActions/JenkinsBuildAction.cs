namespace AvansDevops.DevOps.BuildActions;

public class JenkinsBuildAction : BuildAction
{
    
    public override bool Build()
    {
        Console.WriteLine("Running Jenkins build");
        return true;
    }
    
}