namespace AvansDevops.DevOps.TestActions;

public class PublishTestResultAction : TestAction
{
    
    public override bool RunTestAction()
    {
        Console.WriteLine("Publishing test results");
        return true;
    }
    
}