namespace AvansDevops.DevOps.UtilityActions;

public class FilesCopyUtilityAction(string context) : UtilityAction(context)
{
    
    public override bool RunUtilityAction()
    {
        Console.WriteLine($"Copied file {context}");
        return true;
    }
    
}