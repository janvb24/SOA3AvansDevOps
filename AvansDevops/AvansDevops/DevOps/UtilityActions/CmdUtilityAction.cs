namespace AvansDevops.DevOps.UtilityActions;

public class CmdUtilityAction(string context) : UtilityAction(context)
{
    
    public override bool RunUtilityAction()
    {
        Console.WriteLine($"Running CMD command: {context}");
        return true;
    }
    
}