namespace AvansDevops.DevOps.UtilityActions;

public class FilesDeleteUtilityAction(string context) : UtilityAction(context)
{
    
    public override bool RunUtilityAction()
    {
        Console.WriteLine($"Deleted file from {context}");
        return true;
    }
    
}