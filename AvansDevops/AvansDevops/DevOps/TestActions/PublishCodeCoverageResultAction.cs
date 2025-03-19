namespace AvansDevops.DevOps.TestActions;

public class PublishCodeCoverageResultAction : TestAction
{
    
    public override bool RunTestAction()
    {
        Console.WriteLine("Publishing code coverage results");
        return true;
    }
    
}