namespace AvansDevops.DevOps.UtilityActions;

public class BatchUtilityAction(string context) : UtilityAction(context)
{
    
    public override bool RunUtilityAction()
    {
        Console.WriteLine($"Running Batch command: {context}");
        return true;
    }
    
}