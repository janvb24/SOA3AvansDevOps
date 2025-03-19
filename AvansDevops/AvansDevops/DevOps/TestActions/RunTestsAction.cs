namespace AvansDevops.DevOps.TestActions;

public class RunTestsAction : TestAction
{
    
    public override bool RunTestAction()
    {
        Console.WriteLine("Running tests");
        return true;
    }
    
}